export class BallotBox {
    id:number;
    numBallot:string;
    city:string;
    MIdentity:string;


    constructor(id:number,numBallot:string,city:string,MIdentity:string) 
    {
        this.id=id;
        this.numBallot=numBallot;
        this.city=city;
        this.MIdentity=MIdentity;
    }
}
