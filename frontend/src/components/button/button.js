import styles from './button.module.scss';

const Button = ({ content, onClick, children, type = 'button' }) => {
  const onClickHandler = (event) => {
    onClick && onClick(event);
  };

  return (
    <button
      type={type}
      className={styles.primaryButton}
      onClick={onClickHandler}
      content={content}
    >
      {children}
    </button>
  );
};

export default Button;
