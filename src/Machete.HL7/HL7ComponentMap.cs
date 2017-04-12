﻿namespace Machete.HL7
{
    public class HL7ComponentMap<TComponent, TComponentSchema> :
        HL7EntityMap<TComponent>
        where TComponent : TComponentSchema
        where TComponentSchema : HL7Component
    {
        protected HL7ComponentMap()
        {
            Set(x => x.IsEmpty, IsComponentEmpty);

            Value(x => x.Fields, 0);
        }

        static bool IsComponentEmpty(TextSlice slice)
        {
            for (int i = 0;; i++)
            {
                TextSlice nextSlice;
                if (!slice.TryGetSlice(i, out nextSlice))
                    return true;

                TextSlice nextNextSlice;
                if (nextSlice.TryGetSlice(0, out nextNextSlice))
                    return false;
            }
        }
    }
}