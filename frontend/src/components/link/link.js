import * as NextLink from 'next/link';
import styles from './link.module.scss';

export const LINK_COLORS = {
  Primary: 'primary',
  Secondary: 'secondary',
};

const Link = ({ color = LINK_COLORS.Primary, href, content, className }) => {
  return (
    <NextLink
      className={`${styles.link} ${styles['color-' + color]} ${className}`}
      href={href}
    >
      {content}
    </NextLink>
  );
};

export default Link;
