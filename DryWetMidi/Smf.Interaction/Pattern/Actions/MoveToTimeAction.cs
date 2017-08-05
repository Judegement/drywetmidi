﻿namespace Melanchall.DryWetMidi.Smf.Interaction
{
    internal sealed class MoveToTimeAction : IPatternAction
    {
        #region Constructor

        public MoveToTimeAction()
            : this(null)
        {
        }

        public MoveToTimeAction(ITime time)
        {
            Time = time;
        }

        #endregion

        #region Properties

        public ITime Time { get; }

        #endregion

        #region IPatternAction

        public PatternActionResult Invoke(long time, PatternContext context)
        {
            context.SaveTime(time);
            return new PatternActionResult(Time != null
                ? TimeConverter.ConvertFrom(Time, context.TempoMap)
                : context.RestoreTime());
        }

        #endregion
    }
}
