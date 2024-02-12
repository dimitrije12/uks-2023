import styles from './input.module.scss';

const Input = ({ labelFor, labelContent, type, name, id, placeholder }) => {
  return (
    <div>
      <label htmlFor={labelFor} className={styles.label}>
        {labelContent}
      </label>
      <input
        type={type}
        name={name}
        id={id}
        className={styles.input}
        placeholder={placeholder}
        required=""
      />
    </div>
  );
};

export default Input;
