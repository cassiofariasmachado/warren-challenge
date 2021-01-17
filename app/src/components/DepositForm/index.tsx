import { TextField } from '@material-ui/core';
import React, { useState } from 'react';
import { SubmitButton } from './styles';

interface DepositFormProps {
  onSubmit?: (value: number) => void;
}

export const DepositForm: React.FC<DepositFormProps> = ({ onSubmit }) => {
  const [value, setValue] = useState(0);

  return (
    <form
      onSubmit={(event) => {
        event.preventDefault();
        onSubmit && onSubmit(value);
      }}
    >
      <TextField
        id="value"
        label="Valor"
        variant="outlined"
        margin="dense"
        type="number"
        value={value}
        onChange={(event) => setValue(parseFloat(event.target.value))}
        fullWidth
      />

      <SubmitButton type="submit" variant="contained" color="primary" fullWidth>
        Depositar
      </SubmitButton>
    </form>
  );
}

export default DepositForm;
