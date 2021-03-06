﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class Loop2420F_837PMap :
        X12LayoutMap<Loop2420F_837P, X12Entity>
    {
        public Loop2420F_837PMap()
        {
            Id = "2420F";
            Name = "Referring Provider Name";
                                    
            Segment(x => x.ReferringProvider, 0,
                x => x.Condition = parser => parser.Where(p => p.EntityIdentifierCode.IsEqualTo("DN") ||
                                                               p.EntityIdentifierCode.IsEqualTo("P3")));
            Segment(x => x.SecondaryIdentification, 1);
        }
    }
}