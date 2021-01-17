import { Container, TextField } from '@material-ui/core';
import { Transaction, Account } from '../../types';
import React, { useEffect, useState } from 'react';
import { getAccount, listTransactionsHistory } from '../../api';
import { TransactionsHistoryList, AccountInfo } from '../../components';
import { useHistory } from 'react-router-dom';
import { Title, MenuButton } from './styles';

export const TransactionsHistory: React.FC = () => {
  const [transactionsHistory, setTransactionsHistory] = useState<Transaction[]>([]);
  const [accountId, setAccountId] = useState<number>(1);
  const [account, setAccount] = useState<Account>();
  const history = useHistory();

  useEffect(() => {
    const loadTransactionsHistory = async () => {
      const transactions = await listTransactionsHistory(accountId);

      if (transactions)
        setTransactionsHistory(transactions);
    };

    const loadAccountInfo = async () => {
      setAccount(await getAccount(accountId));
    }

    loadTransactionsHistory();
    loadAccountInfo();
  }, [accountId]);

  return (
    <Container maxWidth="lg">
      <Title variant="h4">
        Histórico de transações
      </Title>

      <TextField
        id="value"
        label="Nº Conta"
        variant="outlined"
        margin="dense"
        type="number"
        value={accountId}
        onChange={(event) => setAccountId(parseInt(event.target.value))}
        fullWidth
      />

      <AccountInfo account={account} />

      <MenuButton
        variant="contained"
        color="primary"
        onClick={() => history.push(`/deposit/${accountId}`)}
      >
        Depositar
      </MenuButton>
      <MenuButton
        variant="contained"
        color="primary"
        onClick={() => history.push(`/withdraw/${accountId}`)}
      >
        Sacar
      </MenuButton>
      <MenuButton
        variant="contained"
        color="primary"
        onClick={() => history.push(`/payment/${accountId}`)}
      >
        Pagar
      </MenuButton>

      <TransactionsHistoryList transactions={transactionsHistory} />
    </Container>
  );
};
