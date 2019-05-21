export class City {
    id:number;
    areaKod:string;
    city:string;
    nowCountValid:number;
    allCountValid:string;

    constructor(id:number,areaKod:string,city:string,nowCountValid:number,allCountValid:string) 
    {
        this.id=id;
        this.areaKod=areaKod;
        this.city=city;
        this.nowCountValid=nowCountValid;
        this.allCountValid=allCountValid;
    }
}
