import {
  Paper, Table, TableContainer, TableRow, TableHead, TableCell, TableBody
} from '@material-ui/core';
import React from 'react';
import { Transaction } from '../../types';
import { formatDate } from '../../utils';

interface TransactionsHistoryListProps {
  transactions: Transaction[]
};

export const TransactionsHistoryList: React.FC<TransactionsHistoryListProps> =
  ({ transactions }) => {
    return (
      <TableContainer component={Paper}>
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell align="right">Tipo</TableCell>
              <TableCell align="right">Valor</TableCell>
              <TableCell align="right">Saldo</TableCell>
              <TableCell align="right">Data / Hora</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {transactions.map((transaction) => (
              <TableRow key={transaction.id}>
                <TableCell component="th" scope="row">
                  {transaction.id}
                </TableCell>
                <TableCell align="right">{transaction.operationType}</TableCell>
                <TableCell align="right">R$ {transaction.operationValue.toFixed(2)}</TableCell>
                <TableCell align="right">R$ {transaction.balance.toFixed(2)}</TableCell>
                <TableCell align="right">{formatDate(transaction.date)}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
  }