/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Infrastructure.Events;

namespace Events
{
    public class CaseReportReceived : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public Guid? DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesOver5 { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesOver5 { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}