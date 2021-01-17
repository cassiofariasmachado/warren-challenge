import { Container } from '@material-ui/core';
import React from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { deposit } from '../../api';
import { DepositForm } from '../../components'
import { Title } from './styles';

interface DepositScreenParams {
  accountId?: string;
}

export const Deposit: React.FC = () => {
  const history = useHistory();
  const { accountId } = useParams<DepositScreenParams>();

  const onSubmit = async (value: number) => {
    if (!accountId) {
      alert('Conta não informada.');
      return;
    }

    await deposit(parseInt(accountId), value);
    history.push('/');
  };

  return (
    <Container maxWidth="sm">
      <Title variant="h4">
        Depósito
      </Title>
      <DepositForm onSubmit={onSubmit} />
    </Container>
  );
};
