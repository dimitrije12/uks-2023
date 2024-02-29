import React from 'react';
import styles from './link.module.scss';
import { Link } from 'react-router-dom';

export const LINK_COLORS = {
  Primary: 'primary',
  Secondary: 'secondary',
};

const CustomLink = ({
  color = LINK_COLORS.Primary,
  to,
  content,
  className,
}) => {
  return (
    <Link
      className={`${styles.link} ${styles['color-' + color]} ${className}`}
      to={to}
    >
      {content}
    </Link>
  );
};

export default CustomLink;
