export class Cazare {
    oras: string;
    dataCheckIn: Date;
    dataCheckOut: Date;
    numeHotel: string;
    constructor(oras: string, dataCheckIn: Date, dataCheckOut: Date, numeHotel: string) {
        this.oras = oras;
        this.dataCheckIn = dataCheckIn;
        this.dataCheckOut = dataCheckOut;
        this.numeHotel = numeHotel;
    }
}