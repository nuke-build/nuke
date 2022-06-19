import React, {useEffect, useRef} from 'react';
import BrowserOnly from '@docusaurus/BrowserOnly';
import clsx from 'clsx'
import styles from './AsciinemaPlayer.module.css';

const AsciinemaPlayer = ({src, ...asciinemaOptions}) => {
    return (
        <BrowserOnly>
            {() => {
                const AsciinemaPlayerLibrary = require('asciinema-player');
                const ref = useRef(null);

                useEffect(() => {
                    const currentRef = ref.current;
                    AsciinemaPlayerLibrary.create(src, currentRef, asciinemaOptions);
                }, [src]);

                return (
                    <>
                        <div ref={ref}/>
                        <div className={clsx(styles.controlInfo)}>
                            Use <kbd>Space</kbd> to pause/play, <kbd>&#11013;</kbd> and <kbd>&#11157;</kbd> to seek backward/forward, or <kbd>F</kbd> to fullscreen.
                        </div>
                    </>
                );
            }}
        </BrowserOnly>
    );
};

export default AsciinemaPlayer;
