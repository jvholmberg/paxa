import { environment } from '@environments/environment';

const logger = (type: string, message: string, ...args) => {
  if (environment.production) { return; }
  console.log(`${type}: ${message}`, ...args);
};

export const logInfo = (message: string, ...args) => logger('INFO', message, ...args);
export const logSuccess = (message: string, ...args) => logger('SUCCESS', message, ...args);
export const logError = (message: string, ...args) => logger('ERROR', message, ...args);
export const logWarning = (message: string, ...args) => logger('WARNING', message, ...args);
