import React from 'react';
import styles from './pageWrapper.module.scss';

export const PAGE_WRAPPER_ORIENTATION = {
  TopCenter: 'topCenter',
  Center: 'center',
};

const PageWrapper = ({
  children,
  orientation = PAGE_WRAPPER_ORIENTATION.Center,
}) => {
  return (
    <div
      className={`${styles.wrapper} ${styles[`orientation-${orientation}`]}`}
    >
      {children}
    </div>
  );
};

export default PageWrapper;
