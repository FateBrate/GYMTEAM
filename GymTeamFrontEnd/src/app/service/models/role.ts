export enum Uloga {
  Admin = 1,
  Employee = 2,
  GuestUser = 3,
}
export function getRoleName(role: Uloga): string {
  switch (role) {
    case Uloga.Admin:
      return 'Administrator';
    case Uloga.Employee:
      return 'Employee';
    case Uloga.GuestUser:
      return 'Guest user';
    default:
      throw new Error(`Unknown role: ${role}`);
  }
}

// Call the function with a Uloga value
const roleName = getRoleName(Uloga.Admin);

// Output: "Administrator"
