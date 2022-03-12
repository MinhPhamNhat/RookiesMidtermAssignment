import { Role } from ".";

export type User = {
  UserId: number;
  Name: string;
  RoleId: number;
  Role: Role;
  IdentityUsername: string;
}
