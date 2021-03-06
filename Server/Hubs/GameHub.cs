﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessVariants.Shared.Base;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace ChessVariants.Server.Hubs
{
    public class GameHub : Hub
    {

        private IMemoryCache _cache;

        public GameHub(IMemoryCache cache)
        {
            _cache = cache;
            if (!_cache.TryGetValue("MatchCacheKey", out List<Match> Matches))
            {
                _cache.Set("MatchCacheKey", new List<Match>());
            }
        }

        public async Task SendMove(string gameId, Move move)
        {
            List<Match> matches = _cache.Get<List<Match>>("MatchCacheKey");
            Match match = matches.FirstOrDefault(_ => _.Id == gameId);
            if (match != null)
            {
                if (match.CurrentTurn.ConnectionId == Context.ConnectionId)
                {
                    if (match.game.PlayMove(move))
                    {
                        foreach (Player player in match.Players)
                        {
                            await Clients.Client(player.ConnectionId).SendAsync("ExecuteMove", move);
                        } 
                    }
                    else
                    {
                        throw new HubException("Invalid Move");
                    }
                } 
                else
                {
                    throw new HubException("Not your turn");
                }
            }
            throw new HubException("Unauthorized");
        }

        public async Task JoinRoom(string gameId)
        {
            List<Match> matches = _cache.Get<List<Match>>("MatchCacheKey");
            Match match = matches.FirstOrDefault(_ => _.Id == gameId);
            if (match != null)
            {
                if (match.Players.Find(x => x.ConnectionId == Context.ConnectionId) == null)
                {
                    Player player = new Player(Context.ConnectionId);
                    match.Players.Add(player);
                    foreach (Player p in match.Players)
                    {
                        await Clients.Client(p.ConnectionId).SendAsync("Log", $"{Context.ConnectionId} joined");
                    }
                }
            } 
            else
            {
                Match newMatch = new Match(gameId);
                newMatch.Players.Add(new Player(Context.ConnectionId));
                matches.Add(newMatch);
                foreach (Player p in newMatch.Players)
                {
                    await Clients.Client(p.ConnectionId).SendAsync("Log", $"{Context.ConnectionId} joined");
                }
            }
        }

        public async Task LeaveRoom(string gameId)
        {
            List<Match> matches = _cache.Get<List<Match>>("MatchCacheKey");
            Match match = matches.FirstOrDefault(_ => _.Id == gameId);
            if (match != null)
            {
                match.Players.Remove(match.Players.Find(x => x.ConnectionId == Context.ConnectionId));
                foreach (Player player in match.Players)
                {
                    await Clients.Client(player.ConnectionId).SendAsync("Log", $"{Context.ConnectionId} left");
                }
            }
        }
    }
}
