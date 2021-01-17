import { Typography } from '@material-ui/core';
import React from 'react';
import { Account } from '../../types';
import { Container } from './styles';

interface AccountInfoProps {
  account?: Account;
}

export const AccountInfo: React.FC<AccountInfoProps> = ({ account }) => {
  debugger;
  if (!account) {
    return (
      <Container>
        <Typography>Conta não encontrada</Typography>
      </Container>
    );
  }

  return (
    <Container>
      <Typography variant="h5">Informações da conta</Typography>
      <Typography>Nº Conta: {account?.id}</Typography>
      <Typography>Saldo: {account?.balance}</Typography>
      <Typography>Usuário: {account?.user?.name}</Typography>
    </Container>
  );
};
