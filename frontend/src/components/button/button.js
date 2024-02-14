import Spinner from '../spinner/spinner';
import styles from './button.module.scss';

const BUTTON_COLORS = {
  Primary: 'primary',
  Secondary: 'secondary',
};

const Button = ({
  content,
  onClick,
  children,
  type = 'button',
  color = BUTTON_COLORS.Primary,
  isLoading = false,
  className,
}) => {
  const onClickHandler = (event) => {
    onClick && !isLoading && onClick(event);
  };

  return (
    <button
      type={type}
      className={`${styles.button} ${styles[`color-${color}`]} ${className}`}
      onClick={onClickHandler}
      content={content}
    >
      {children}
      {isLoading && <Spinner className="absolute right-4" />}
    </button>
  );
};

export default Button;
