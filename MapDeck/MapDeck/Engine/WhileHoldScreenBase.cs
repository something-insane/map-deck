using System;
using System.Linq;

namespace MapDeck.Engine
{
    /// <summary>
    ///     A screen that displays itself until no buttons are held.
    /// </summary>
    public abstract class WhileHoldScreenBase : ScreenBase
    {
        private readonly ScreenBase _goBackTo;

        public WhileHoldScreenBase(
            ScreenManager screenManager,
            ScreenBase goBackTo)
            : base(screenManager)
        {
            this._goBackTo = goBackTo ?? throw new ArgumentNullException(nameof(goBackTo));
        }

        public override string Name => "Explainer";

        public override void Activate()
        {
            if (!this.AllKeysAreReleased())
                base.Activate();
            else
                throw new InvalidOperationException("No keys are being held.");
        }

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (this.AllKeysAreReleased())
                this._goBackTo.Activate();
        }

        private bool AllKeysAreReleased()
        {
            var anyKeyDown = this.ScreenManager.KeyStates.Any(k => k.IsDown);
            return !anyKeyDown;
        }
    }
}
