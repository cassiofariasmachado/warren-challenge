import { TextField } from '@material-ui/core';
import React, { useState } from 'react';
import { SubmitButton } from './styles';

interface WithdrawFormProps {
  onSubmit?: (value: number) => void;
}

export const WithdrawForm: React.FC<WithdrawFormProps> = ({ onSubmit }) => {
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
        Sacar
      </SubmitButton>
    </form>
  );
};

export default WithdrawForm;
