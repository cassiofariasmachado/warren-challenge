import { Transaction, Account } from '../types';
import { createInstace } from './axios';

const axiosInstance = createInstace();

export const listTransactionsHistory = async (accountId: number): Promise<Transaction[] | undefined> => {
    const response = await axiosInstance.get(`accounts/${accountId}/transactions`);

    return response?.data;
}

export const getAccount = async (accountId: number): Promise<Account | undefined> => {
    const response = await axiosInstance.get(`accounts/${accountId}`);
    
    return response?.data;
}

export const deposit = async (accountId: number, value: number): Promise<void> =>
    await axiosInstance.post(`accounts/${accountId}/deposit`, { value })

export const withdraw = async (accountId: number, value: number): Promise<void> =>
    await axiosInstance.post(`accounts/${accountId}/withdraw`, { value })

export const payment = async (accountId: number, value: number): Promise<void> =>
    await axiosInstance.post(`accounts/${accountId}/payment`, { value })