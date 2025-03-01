import { DatePicker, DatePickerProps } from '@mui/x-date-pickers/DatePicker';
import {
  FieldValues,
  useController,
  UseControllerProps,
} from 'react-hook-form';

type Props<T extends FieldValues> = {
  label: string;
  name: keyof T;
} & UseControllerProps<T> &
  DatePickerProps<Date, any>;

export default function AppDatePicker<T extends FieldValues>(props: Props<T>) {
  const { fieldState, field } = useController({ ...props });

  return (
    <DatePicker
      {...props}
      {...field}
      fullWidth
      value={field.value || null}
      variant='inline'
      inputVariant='outlined'
      error={!!fieldState.error}
      helperText={fieldState.error?.message}
    />
  );
}
