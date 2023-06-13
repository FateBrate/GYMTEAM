import { Uloga } from './role';

export interface IUser {
  email: string;
  lozinka: string;
  id: number;
  ime: string;
  prezime: string;
  putanjaSlike: string;
  roleId: number;
  role: Uloga;
  brojTelefona: string;
  datumRodjenja: string;
}
