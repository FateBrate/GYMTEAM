import { IUser } from './user';

export interface IAuth {
  id: number;
  ipAdresa: string;
  korisnik: Partial<IUser>;
  korisnikId: number;
  vrijednost: string;
  vrijemeEvidentiranja: string;
}

export interface ILoginResponse {
  autentifikacijaToken: IAuth;
  isLogiran: boolean;
}
