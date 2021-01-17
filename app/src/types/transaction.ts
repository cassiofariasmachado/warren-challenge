export interface Transaction {
    id: number;
    operationType: string;
    operationValue: number;
    balance: number;
    date: Date;
}