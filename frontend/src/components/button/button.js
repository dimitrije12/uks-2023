import Spinner from '../spinner/spinner';
import styles from './button.module.scss';

const Button = ({
  content,
  onClick,
  children,
  type = 'button',
  isLoading = false,
}) => {
  const onClickHandler = (event) => {
    onClick && !isLoading && onClick(event);
  };

  return (
    <button
      type={type}
      className={styles.primaryButton}
      onClick={onClickHandler}
      content={content}
    >
      {children}
      {isLoading && <Spinner className="absolute right-4" />}
    </button>
  );
};

export default Button;
