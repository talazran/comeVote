export class Managers {
    MIdentity:string;
    MFullName:string;
    MUserName:string;
    MPassword:string;
    NumStatus:string;

    constructor( MIdentity:string,MFullName:string,MUserName:string,MPassword:string,NumStatus:string)
    {
        this.MIdentity=MIdentity;
        this.MFullName=MFullName;
        this.MUserName=MUserName;
        this.MPassword=MPassword;
        this.NumStatus=NumStatus;
    }
}
