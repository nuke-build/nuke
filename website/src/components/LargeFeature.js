import React from 'react'
import clsx from 'clsx'

import styles from './LargeFeature.module.css'

export default function LargeFeature({ sectionStyle, reversed, title, first, second}) {
    const firstColumn =
        <div className={clsx('col', 'col--6', styles.featureSection)}>
            <h2>{title}</h2>
            {first}
        </div>
    const secondColumn =
        <div className="col col--6">
            {second}
        </div>

    return (
        <div className={sectionStyle}>
            <div className="container highlightSection">
                <div className={
                    clsx(
                        styles.largeFeatureRow,
                        reversed ? styles.largeFeatureRowReversed : undefined,
                        'row')
                }>
                    {reversed ? (
                        <>
                            {secondColumn}
                            {firstColumn}
                        </>
                    ) : (
                        <>
                            {firstColumn}
                            {secondColumn}
                        </>
                    )}
                </div>
            </div>
        </div>
    )
}
