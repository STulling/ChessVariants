using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Base
{
	public class Rule

	/*  The Rule class encapsulates a (potentially) configurable "rule" that can be 
		plugged into a Game.  By separating the rules for a game into these plugable 
		modules, it makes it much easier to define new games.  Most Chess variants 
		are built with combinations of the same basic rules.  And, if a Game has a 
		brand new rule, implementing it in this way allows it to be reused in new 
		games.  This is why the architecture is designed such that the Game class 
		doesn't have the ability to override move generation directly.  */

	{
		// *** PROPERTIES *** //
		/*

		public Board Board { get; protected set; }
		public Game Game { get; protected set; }


		// *** CONSTRUCTION *** //

		public Rule()
		{ }


		// *** OVERRIDABLE VIRTUAL FUNCTIONS *** //

		public virtual void Initialize(Game game)
		{ Game = game; Board = game.Board; }

		public virtual void PostInitialize()
		{ }

		public virtual void ClearGameState()
		{ }

		public virtual void ReleaseMemoryAllocations()
		{ }

		public virtual void PositionLoaded(FEN fen)
		{ }

		public virtual void SetDefaultsInFEN(FEN fen)
		{ }

		public virtual void SavePositionToFEN(FEN fen)
		{ }

		public virtual void RuleRemoved()
		{ }

		public virtual UInt64 GetPositionHashCode(int ply)
		{ return 0; }

		public virtual MoveEventResponse MoveBeingGenerated(MoveList moves, int from, int to, MoveType type)
		{ return MoveEventResponse.NotHandled; }

		public virtual MoveEventResponse MoveBeingMade(MoveInfo move, int ply)
		{ return MoveEventResponse.NotHandled; }

		public virtual MoveEventResponse MoveMade(MoveInfo move, int ply)
		{ return MoveEventResponse.NotHandled; }

		public virtual MoveEventResponse MoveBeingUnmade(MoveInfo move, int ply)
		{ return MoveEventResponse.NotHandled; }

		public virtual bool IsSquareAttacked(int square, int side)
		{ return false; }

		public virtual MoveEventResponse TestForWinLossDraw(int currentPlayer, int ply)
		{ return MoveEventResponse.NotHandled; }

		public virtual MoveEventResponse NoMovesResult(int currentPlayer, int ply)
		{ return MoveEventResponse.NotHandled; }

		public virtual void GenerateSpecialMoves(MoveList list, bool capturesOnly, int ply)
		{ }

		public virtual void AdjustEvaluation(int ply, ref int midgameEval, ref int endgameEval)
		{ }

		public virtual MoveEventResponse DescribeMove(MoveInfo move, MoveNotation format, ref string description)
		{ return MoveEventResponse.NotHandled; }

		public virtual int PositionalSearchExtension(int currentPlayer, int ply)
		{ return 0; }

		public virtual void GetNotesForPieceType(PieceType type, List<string> notes)
		{ }
		*/
	}
}
