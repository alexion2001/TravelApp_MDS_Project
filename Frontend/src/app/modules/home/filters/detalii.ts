export class Detalii {
    email: string;
    orasPlecare: string;
    orasDestinatie: string;
    dataPlecare: Date;
    dataSosire: Date;
    buget: number;
    constructor(
        email: string,
        orasPlecare: string,
        orasDestinatie: string,
        dataPlecare: Date,
        dataSosire: Date,
        buget: number
    ) {
        this.email = email;
        this.orasPlecare = orasPlecare;
        this.orasDestinatie = orasDestinatie;
        this.dataPlecare = dataPlecare;
        this.dataSosire = dataSosire;
        this.buget = buget;
    }
}