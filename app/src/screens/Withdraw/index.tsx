import { Container } from '@material-ui/core';
import React from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { withdraw } from '../../api';
import { WithdrawForm } from '../../components';
import { Title } from './styles';

interface WithdrawScreenParams {
  accountId?: string;
}

export const Withdraw: React.FC = () => {
  const history = useHistory();
  const { accountId } = useParams<WithdrawScreenParams>();

  const onSubmit = async (value: number) => {
    if (!accountId) {
      alert('Conta não informada.');
      return;
    }

    await withdraw(parseInt(accountId), value);
    history.push('/');
  };

  return (
    <Container maxWidth="sm">
      <Title variant="h4">
        Saque
      </Title>
      <WithdrawForm onSubmit={onSubmit} />
    </Container>
  );
};
