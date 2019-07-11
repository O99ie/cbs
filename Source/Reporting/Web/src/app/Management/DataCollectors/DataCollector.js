/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class DataCollector extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '2985c11e-1b80-4741-8f25-22864a3e9f6d',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.fullName = '';
        this.displayName = '';
        this.yearOfBirth = 0;
        this.sex = 0;
        this.preferredLanguage = 0;
        this.location = {};
        this.district = '';
        this.region = '';
        this.village = '';
        this.phoneNumbers = [];
        this.registeredAt = new Date();
        this.dataVerifier = '00000000-0000-0000-0000-000000000000';
        this.inTraining = false;
    }
}