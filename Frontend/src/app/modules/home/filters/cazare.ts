export class Cazare {
    oras: string;
    dataCheckIn: Date;
    dataCheckOut: Date;
    buget: string;
    constructor(oras: string, dataCheckIn: Date, dataCheckOut: Date, buget: string) {
        this.oras = oras;
        this.dataCheckIn = dataCheckIn;
        this.dataCheckOut = dataCheckOut;
        this.buget = buget;
    }
}