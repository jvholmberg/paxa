import addSeconds from 'date-fns/addSeconds';
import addMinutes from 'date-fns/addMinutes';
import addHours from 'date-fns/addHours';
import addDays from 'date-fns/addDays';
import addBusinessDays from 'date-fns/addBusinessDays';
import addWeeks from 'date-fns/addWeeks';
import addMonths from 'date-fns/addMonths';
import addYears from 'date-fns/addYears';

export const inFifteenSeconds = () => addSeconds(new Date(), 15);
export const inThirtySeconds = () => addSeconds(new Date(), 30);
export const inFortyfiveSeconds = () => addSeconds(new Date(), 45);
export const inOneMinute = () => addMinutes(new Date(), 1);
export const inFifteenMinutes = () => addMinutes(new Date(), 15);
export const inThirtyMinutes = () => addMinutes(new Date(), 30);
export const inFortyfiveMinutes = () => addMinutes(new Date(), 45);
export const inOneHour = () => addHours(new Date(), 1);
export const inFiveHours = () => addHours(new Date(), 5);
export const inTenHour = () => addHours(new Date(), 10);
export const inFifteenHour = () => addHours(new Date(), 15);
export const inOneDay = () => addDays(new Date(), 1);

