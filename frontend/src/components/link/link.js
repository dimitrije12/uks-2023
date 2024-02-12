import styles from './link.module.scss';

export const LINK_VARIATIONS = {
  Primary: 'primary',
  Secondary: 'secondary',
};

const Link = ({
  linkVariation = LINK_VARIATIONS.Primary,
  href,
  content,
  className,
}) => {
  return (
    <a
      className={`${styles.link} ${
        styles['variation-' + linkVariation]
      } ${className}`}
      href={href}
    >
      {content}
    </a>
  );
};

export default Link;
