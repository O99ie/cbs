﻿/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class CaseReportFromUnknownDataCollector extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '427ba081-4bad-4dc5-a3da-bbe95b5b6fa7',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.message = '';
        this.origin = '';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.numberOfFemalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfMalesUnder5 = 0;
        this.timestamp = new Date();
    }
}