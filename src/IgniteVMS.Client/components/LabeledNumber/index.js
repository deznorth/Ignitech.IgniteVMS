import React from 'react';
import { Link } from 'react-router-dom';

import './styles.scss';

const LabeledNumber = props => {
  const {
    label,
    value,
    path,
  } = props;

  const cn = 'labelednumber';

  return (
    <div className={cn}>
      <Link
        to={path}
        className={`${cn}_link`}
      >
        {label}
      </Link>
      <p className={`${cn}_value`}>{value}</p>
    </div>
  );
};

export default LabeledNumber;
