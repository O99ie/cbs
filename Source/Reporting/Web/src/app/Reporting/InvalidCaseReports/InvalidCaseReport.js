/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class InvalidCaseReport extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'ee2a7e9f-11eb-4965-9a60-954845cb411d',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.origin = '';
        this.message = '';
        this.parsingErrorMessage = [];
        this.timestamp = new Date();
    }
}