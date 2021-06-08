import { Customer } from "./customer.model";
import { Employee } from "./employee.model";
import { Price } from "./price.model";

export interface ServiceOrder {
    id?: number;
    number: string;
    title: string;
    executionDate: Date;
    price: Price;
    priceId: number;
    employee?: Employee;
    employeeId: number;
    customer?: Customer;
    customerId: number;
}