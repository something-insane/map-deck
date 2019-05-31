using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OpenMacroBoard.NetCore.SDK;
using StreamDeckSharp.NetCore;

namespace MapDeck.Engine
{
    public abstract class ScreenBase
    {
        private readonly KeyBitmap[,] _keyBitmaps = new KeyBitmap[5, 3];
        protected readonly ScreenManager ScreenManager;

        protected ScreenBase(ScreenManager screenManager)
            : this(screenManager, KeyBitmap.Black)
        {
        }

        protected ScreenBase(ScreenManager screenManager, KeyBitmap defaultKeyBitmap)
        {
            this.ScreenManager = screenManager ?? throw new ArgumentNullException(nameof(screenManager));

            for (var column = 0; column < 5; column++)
            for (var row = 0; row < 3; row++)
                this._keyBitmaps[column, row] = defaultKeyBitmap ?? throw new ArgumentNullException(nameof(defaultKeyBitmap)); ;
        }

        /// <summary>
        ///     Gets or sets a specific key bitmap, updating the screen in the process.
        /// </summary>
        /// <param name="column">The column. 1/2/3/4/5.</param>
        /// <param name="row">The row. 1/2/3.</param>
        /// <returns>The current KeyBitmap.</returns>
        public KeyBitmap this[int column, int row]
        {
            get
            {
                column--; row--;
                var offBoard = column >= 5 || row >= 3 || column < 0 || row < 0;
                if (offBoard) { throw new IndexOutOfRangeException(); }

                return _keyBitmaps[column, row];
            }

            set
            {
                column--; row--;
                var offBoard = column >= 5 || row >= 3 || column < 0 || row < 0;
                if (offBoard) throw new IndexOutOfRangeException();

                _keyBitmaps[column, row] = value ?? throw new ArgumentNullException(nameof(value));
                if (this.IsActive)
                    this.ScreenManager.Deck.SetKeyBitmap(row * 5 + column, value);
            }
        }

        public virtual void Activate()
        {
            this.ScreenManager.OnScreenActivated(this);
            var wasActive = this.IsActive;
            this.IsActive = true;
            if (!wasActive && this.IsActive)
            {
                this.SetAllKeyBitmaps();
            }
        }

        public virtual void Deactivate()
        {
            this.IsActive = false;
            this.ScreenManager.OnScreenDeactivated(this);
        }

        /// <summary>
        ///     Gets or sets the active state of this Screen.
        ///     When inactive, updating tiles will do nothing.
        ///     When active, this screen will draw to the deck.
        ///     When activated, will draw all its tiles.
        /// </summary>
        public bool IsActive { get; private set; }

        public abstract string Name { get; }

        private void SetAllKeyBitmaps()
        {

            for (var column = 0; column < 5; column++)
            for (var row = 0; row < 3; row++)
                this.ScreenManager.Deck.SetKeyBitmap(row * 5 + column, this._keyBitmaps[column, row]);
        }

        /// <summary>
        ///     Called when a key is pressed or released.
        /// </summary>
        /// <param name="oldKeyState">The old key state.</param>
        /// <param name="newKeyState">The new key state.</param>
        public abstract void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState);
    }
}
