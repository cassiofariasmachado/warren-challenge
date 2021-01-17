import { TransactionsHistory, Deposit, Withdraw } from '../screens';
import { Payment } from '../screens/Payment';

interface Route {
    name: string;
    path: string | string[] | undefined,
    component: React.ComponentType<any> | undefined,
}

export const routes: Route[] = [
    {
        name: 'transactions-history',
        path: '/transactions-history',
        component: TransactionsHistory
    },
    {
        name: 'deposit',
        path: '/deposit/:accountId',
        component: Deposit
    },
    {
        name: 'withdraw',
        path: '/withdraw/:accountId',
        component: Withdraw
    },
    {
        name: 'payment',
        path: '/payment/:accountId',
        component: Payment
    },
    {
        name: 'home',
        path: '/',
        component: TransactionsHistory
    }
]

