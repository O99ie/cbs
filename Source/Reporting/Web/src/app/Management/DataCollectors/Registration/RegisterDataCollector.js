/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterDataCollector extends Command
{
    constructor() {
        super();
        this.type = '8cb965ba-0815-4a06-b706-201584f22e7d';

        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.fullName = '';
        this.displayName = '';
        this.yearOfBirth = 0;
        this.sex = 0;
        this.preferredLanguage = 0;
        this.gpsLocation = {};
        this.phoneNumbers = [];
        this.region = '';
        this.district = '';
        this.dataVerifierId = '00000000-0000-0000-0000-000000000000';
    }
}