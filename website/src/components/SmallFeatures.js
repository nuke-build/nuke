import React from 'react';
import clsx from 'clsx';
import styles from './SmallFeatures.module.css';

function Feature({Svg, title, description}) {
    return (
        <div className={clsx('col col--4')}>
            <div className="text--center">
                <Svg className={styles.featureSvg} alt={title} style={{'width': '180px'}}/>
            </div>
            <div className="text--center padding-horiz--md">
                <h3>{title}</h3>
                <p>{description}</p>
            </div>
        </div>
    );
}

export default function SmallFeatures({sectionStyle, features}) {
    return (
        <section className={sectionStyle}>
            <div className={clsx('container', styles.features)}>
                <div className="row">
                    {features.map((props, idx) => (
                        <Feature key={idx} {...props} />
                    ))}
                </div>
            </div>
        </section>
    );
}
