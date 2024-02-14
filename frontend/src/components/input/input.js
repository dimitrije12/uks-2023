import styles from './input.module.scss';

const Input = ({
  labelFor,
  labelContent,
  type,
  name,
  id,
  value = '',
  placeholder,
  onChange,
  errorMessage,
}) => {
  const onChangeHandler = (event) => {
    onChange && onChange(event);
  };
  return (
    <div className="relative pb-5">
      <label htmlFor={labelFor} className={styles.label}>
        {labelContent}
      </label>
      <input
        type={type}
        name={name}
        id={id}
        value={value}
        className={styles.input}
        placeholder={placeholder}
        required=""
        onChange={onChangeHandler}
      />
      {errorMessage && (
        <div className="text-red-500 text-sm absolute bottom-0 left-2">
          {errorMessage}
        </div>
      )}
    </div>
  );
};

export default Input;
