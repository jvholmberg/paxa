import { environment } from '@environments/environment';
import { of } from 'rxjs';
import { delay } from 'rxjs/Operators';

export const simulate = (response) => {
  const { latencyMultiplier } = environment;
  const latency = Math.floor(Math.random() * latencyMultiplier) + 1;
  return of(response).pipe(delay(latency));
};
