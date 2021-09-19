export interface AuthenticateResponse {
  userId: number;
  personId: number;
  organizationId: number;
  email: string;
  jwtToken: string;
}
