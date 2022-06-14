import React from 'react';
import clsx from 'clsx';
import styles from './Testimonials.module.css';

function Testimonial({name, title, thumbnail, text}) {
    return (
        <div className="col">
            <div className="avatar avatar--vertical margin-bottom--sm">
                <img
                    alt={name}
                    className="avatar__photo avatar__photo--xl"
                    src={thumbnail}
                    style={{overflow: 'hidden'}}
                />
                <div className="avatar__intro padding-top--md">
                    <div className="avatar__name">{name}</div>
                    <small className="avatar__subtitle">{title}</small>
                </div>
            </div>
            <p className="text--center text--italic padding-horiz--md">
                {text}
            </p>
        </div>
    );
}

export default function Testimonials({sectionStyle, quotes}) {
    return (
        <div className={sectionStyle}>
            <div className="container">
                <div className={clsx(styles.testimonialRow, 'row')}>
                    {quotes.map((props, idx) => (
                        <Testimonial key={idx} {...props} />
                    ))}
                </div>
            </div>
        </div>
    );
}
