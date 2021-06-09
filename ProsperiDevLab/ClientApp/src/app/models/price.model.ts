import { Currency } from "./currency.model";

export interface Price {
    id?: number;
    value: number;
    currency?: Currency;
    currencyId: number;
}