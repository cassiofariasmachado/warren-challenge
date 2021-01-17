import { Container } from '@material-ui/core';
import React from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { payment } from '../../api';
import { PaymentForm } from '../../components';
import { Title } from './styles';

interface PaymentScreenParams {
  accountId?: string;
}

export const Payment: React.FC = () => {
  const history = useHistory();
  const { accountId } = useParams<PaymentScreenParams>();

  const onSubmit = async (value: number) => {
    if (!accountId) {
      alert('Conta não informada.');
      return;
    }

    await payment(parseInt(accountId), value);
    history.push('/');
  };

  return (
    <Container maxWidth="sm">
      <Title variant="h4">
        Pagamento
      </Title>
      <PaymentForm onSubmit={onSubmit} />
    </Container>
  );
};
