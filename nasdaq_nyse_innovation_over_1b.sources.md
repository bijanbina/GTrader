# Nasdaq and NYSE high-tech and innovation stock universe

Ticker file: `nasdaq_nyse_innovation_over_1b.txt`
Generated: 2026-09-14T10:02:51+00:00
Symbols: 1,148 (685 Nasdaq, 463 NYSE); distinct company names: 1,137.
Expansion: 578 additions to the prior 570-symbol file. All prior symbols are retained.

The ticker file contains exactly one symbol per line, alphabetically sorted, without a header, blank lines or duplicate symbols. It is ASCII text with LF newlines.

## Definition and filters

This is a broad industry-based high-tech and innovation universe, supplemented with documented technology businesses whose exchange-sector labels fall elsewhere. Innovation is not a standard exchange field or an objective yes/no financial metric. Complete selected industry screens provide the systematic core; company-profile additions cover the specific cross-industry themes below. This is not an innovation ranking or an assertion that every innovative company in the world is included.

- Exchange: Nasdaq or the New York Stock Exchange (NYSE). All Nasdaq tiers are included. NYSE American, NYSE Arca, Cboe-only, OTC and overseas-only listings are outside this screen.
- Market capitalization: strictly greater than US$1,000,000,000, using the exact numeric company market cap reported in the same-day exchange snapshots.
- Securities: listed common/ordinary shares and ADRs/ADSs, including distinct common share classes. ETFs, closed-end funds, preferred shares, warrants, rights, acquisition units and bonds are excluded.
- Geography: any country, provided the common share or ADR/ADS meets the listing requirement.
- Snapshot: source data retrieved on 14 September 2026. Sampled quote pages use the 11 September 2026 regular-session close. The file does not update continuously.

## Included business areas

- Technology, software, semiconductors, semiconductor equipment/materials, hardware, communications equipment, scientific instruments, IT services and solar technology.
- Telecom, internet platforms, e-commerce, gaming software, direct streaming, online travel and advertising technology.
- Automobile manufacturers, component suppliers, dealerships/services, vehicle auctions, trucks, buses, specialty vehicles, recreational road vehicles and motorcycles.
- Aerospace and defense: aircraft, spacecraft, satellites, defense systems, suppliers, and documented defense technology/engineering service providers.
- Biotechnology, biological drug discovery, general pharmaceutical manufacturers, specialty/generic drug developers and manufacturers.
- Medical devices, medical instruments/supplies, diagnostics, genomics, life-science research tools and digital health systems.
- Industrial automation, robotics, specialty machinery, electrical equipment, batteries, fuel-cell/energy technology, environmental/water controls, agricultural and heavy-construction engineering.
- Specialty chemicals, advanced alloys/materials, precision/digital manufacturing, rare-earth magnets, agricultural biotechnology and crop science.
- Nuclear reactors/fuel technology and selected operating nuclear-power businesses; building controls and thermal management.
- Documented financial technology, electronic trading, payments, digital lending/brokerage, financial data, blockchain infrastructure and operating AI/compute infrastructure businesses.

The broad selection does not automatically include every conventional bank, insurer, utility, miner, fertilizer producer, metal distributor or media company. These businesses need a selected industry classification or a documented technology theme. Marine-only manufacturers and unrelated conventional industries remain outside the original automotive scope.

## Systematic industry screens

Every qualifying entry in the Technology sector and the industries listed below is included, subject to security type and the documented LION classification correction. For selected industry membership, completeness applies to the source snapshot and definitions.

| New industry | Source rows inspected | Lowest source market cap (USD) | Qualifying direct symbols |
| --- | ---: | ---: | ---: |
| [aerospace-and-defense](https://stockanalysis.com/stocks/industry/aerospace-and-defense/) | 92 | 4,903,847 | 57 |
| [biotechnology](https://stockanalysis.com/stocks/industry/biotechnology/) | 500 | 13,124,814 | 168 |
| [drug-manufacturers-general](https://stockanalysis.com/stocks/industry/drug-manufacturers-general/) | 21 | 10,273,167 | 16 |
| [drug-manufacturers-specialty-and-generic](https://stockanalysis.com/stocks/industry/drug-manufacturers-specialty-and-generic/) | 84 | 1,083,073 | 34 |
| [medical-devices](https://stockanalysis.com/stocks/industry/medical-devices/) | 142 | 1,064,077 | 41 |
| [medical-instruments-and-supplies](https://stockanalysis.com/stocks/industry/medical-instruments-and-supplies/) | 51 | 2,837,545 | 29 |
| [diagnostics-and-research](https://stockanalysis.com/stocks/industry/diagnostics-and-research/) | 44 | 3,702,327 | 29 |
| [health-information-services](https://stockanalysis.com/stocks/industry/health-information-services/) | 41 | 1,636,514 | 15 |

Biotechnology has more than 500 total entries, but its first 500 are sorted by descending market cap and reach US$13,124,814, far below the cutoff. Therefore, the first page covers its entire above-cutoff population. BIO.B is an additional verified common share class in diagnostics/research.

| Additional industry | Source rows inspected | Source |
| --- | ---: | --- |
| specialty-industrial-machinery | 76 | [Industry table](https://stockanalysis.com/stocks/industry/specialty-industrial-machinery/) |
| electrical-equipment-and-parts | 53 | [Industry table](https://stockanalysis.com/stocks/industry/electrical-equipment-and-parts/) |
| pollution-and-treatment-controls | 17 | [Industry table](https://stockanalysis.com/stocks/industry/pollution-and-treatment-controls/) |
| specialty-chemicals | 61 | [Industry table](https://stockanalysis.com/stocks/industry/specialty-chemicals/) |
| Farm & Heavy Construction Machinery | 27 | [Industry table](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/) |

The previous 570-symbol screen also covered the full Technology sector and these industries: Telecom Services, Auto Manufacturers, Auto Parts, Auto & Truck Dealerships, Internet Content & Information, Electronic Gaming & Multimedia, and Internet Retail. Supplemental streaming, online-travel, advertising technology, vehicle/component companies from that screen are retained.

## Documented thematic supplements

These additions use business evidence rather than blanket inclusion of their entire formal sector.

| Theme | Supplemental symbols |
| --- | --- |
| Defense technology/engineering services | AMTM, BAH, KBR |
| Industrial automation/materials conglomerates | HON, MMM |
| Building controls and thermal management | AAON, CARR, JCI, LII, SPXC, TT |
| Battery storage and nuclear fuel/reactor technology outside the core tables | CCJ, FLNC, LEU, NXE, OKLO, STDN |
| Agricultural biotechnology/crop science | CTVA, FMC |
| Advanced materials/precision manufacturing | ATI, CRS, ESAB, FOIL, GPGI, ICL, MP, MTRN, PRLB, USAR |
| Nuclear generating infrastructure | CEG, TLN, VST |
| Financial, data and operating digital-infrastructure technology | AFRM, BGC, CLOV, CLSK, CME, COIN, CRCL, EFX, ENVA, ETOR, FDS, FIGR, FUTU, GLXY, GPN, HOOD, HUT, IBKR, ICE, IOND, IREN, KLAR, LMND, MA, MARA, MCO, MIAX, MKTX, MORN, MSCI, NDAQ, NU, OSCR, PYPL, QFIN, RIOT, SEZL, SOFI, SPGI, TRU, TW, UPST, V, VIRT, WULF |

Operating nuclear generators CEG, TLN and VST are explicitly included under the user-approved nuclear-power theme, even though they are not pure-play reactor developers. NXE is a nuclear-fuel project developer. UROY is excluded as a royalty/investment exposure. ICL is included for engineered materials and specialty-chemical capabilities; this does not assume that its discontinued downstream LFP cathode projects are operating. Pure crypto-treasury holdings were not newly included solely for owning digital assets.

Retained original supplemental companies include online travel ABNB/BKNG/EXPE/GBTG/MMYT/TCOM/TRIP; streaming ANGX/FUBO/NFLX/ROKU; advertising/internet APP/DV/LFTO/MGNI/QNST/TTD/ZD; road vehicles DOO/HOG/PII/THO; components CMI/LCII/PATK; and vehicle auctions CPRT.

## Listing and classification checks

- Boeing (BA) is included through Aerospace & Defense.
- Vertex Pharmaceuticals (VRTX) is included through Biotechnology.
- Ventyx Biosciences (VTYX) is excluded because it was acquired by Lilly and delisted. Nasdaq reports last trading on 3 March 2026, merger completion on 4 March and suspension on 5 March. [Nasdaq corporate-action notice](https://www.nasdaqtrader.com/TraderNews.aspx?id=ECA2026-127). Lilly (LLY) is included.
- BIO.B is verified as NYSE Class B common stock. [Bio-Rad SEC filing](https://www.sec.gov/Archives/edgar/data/12208/000001220826000046/bio-20260731.htm). HEI/HEI.A and MOG.A/MOG.B are already represented by the aerospace industry table.
- Separate common classes BELFB, GOOG and ZG are retained. Preferred GOOGM and GOOGN are excluded.
- LION is excluded despite an inconsistent Technology-sector tag: its actual business is conventional film/TV production and distribution, with Industry = Entertainment. [Lionsgate business overview](https://investors.lionsgate.com/overview/).
- Current listed symbols DOO and TE are used; obsolete DOOO, FREY and REVG are excluded.
- NNE, ENVX and SLDP are below US$1 billion in the exchange snapshot. Cboe-only, NYSE American and OTC names do not pass the exchange rule even if relevant to a technology theme.

## Sources and completeness verification

Exchange-universe sources:

- [NASDAQ listing page 1](https://stockanalysis.com/list/nasdaq-stocks/)
- [NASDAQ listing page 2](https://stockanalysis.com/list/nasdaq-stocks/?page=2)
- [NASDAQ listing page 3](https://stockanalysis.com/list/nasdaq-stocks/?page=3)
- [NYSE listing page 1](https://stockanalysis.com/list/nyse-stocks/)
- [NYSE listing page 2](https://stockanalysis.com/list/nyse-stocks/?page=2)
- [NYSE listing page 3](https://stockanalysis.com/list/nyse-stocks/?page=3)
- [Technology sector](https://stockanalysis.com/stocks/sector/technology/)
- [Stock Analysis industry definitions](https://stockanalysis.com/stocks/industry/)
- [Stock Analysis data sources](https://stockanalysis.com/data-sources/)
- [Nasdaq official security directory](https://www.nasdaqtrader.com/dynamic/SymDir/nasdaqlisted.txt)

The two exchange snapshots contain 3,000 distinct entries: 1,500 consecutive ranks per exchange, sorted by descending market cap. Of these, 1,091 Nasdaq and 1,493 NYSE entries exceed the cutoff. The Nasdaq pages end at US$426,055,055 and NYSE pages at US$976,250,733, proving that both searches extend below the cutoff. The Technology-sector page covers 500 rows down to US$273,159,046. Industry pages either contain all rows or extend below the cutoff in descending market-cap order.

All selected rows were joined to the exact exchange snapshot. The final file was independently recomputed and checked for set equality, valid exchange, strict market-cap cutoff, preserved previous symbols, deduplication and one-symbol-per-line formatting. Full official-directory reconciliation for every security was not completed because bulk downloads were unavailable; share-class checks were performed for the identified alternate-class cases.

Market caps and classifications can change, and third-party sources can contain omissions. Industry coverage is systematic; the additional cross-industry innovation themes require documented judgment and are not a mathematical enumeration of every company that innovates.

Supplemental business-evidence sources:

- [AAON](https://www.aaon.com)
- [AFRM](https://investors.affirm.com/)
- [AGCO](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [ALG](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [AMTM](https://www.amentum.com/markets/space/defense-national-security/)
- [ATI](https://www.atimaterials.com/)
- [BAH](https://www.boozallen.com/markets/defense.html)
- [BGC](https://www.bgcg.com/bgc/)
- [BLBD](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [CARR](https://www.carrier.com)
- [CAT](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [CCJ](https://www.cameco.com)
- [CEG](https://www.constellationenergy.com/work/generation/nuclear.html)
- [CLOV](https://investors.cloverhealth.com/news-releases/news-release-details/counterpart-assistant-gets-conversational)
- [CLSK](https://www.cleanspark.com/)
- [CME](https://www.cmegroup.com/solutions/market-tech-and-data-services.html)
- [CNH](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [COIN](https://investor.coinbase.com/home/default.aspx?irgwc=1)
- [CRCL](https://investor.circle.com/overview/)
- [CRS](https://www.carpentertechnology.com/)
- [CTVA](https://www.corteva.com/products-and-services/seeds/seed-randd.html)
- [DE](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [EFX](https://investor.equifax.com/company-information)
- [ENVA](https://www.enova.com/)
- [ESAB](https://esabcorporation.com/)
- [ETOR](https://www.etoro.com/about/)
- [FDS](https://investor.factset.com/investor-relations/)
- [FIGR](https://investors.figure.com/)
- [FLNC](https://fluenceenergy.com)
- [FMC](https://www.fmc.com/en/innovation/biologicals)
- [FOIL](https://www.londianwason.com/)
- [FSS](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [FUTU](https://ir.futuholdings.com/corporate/company-profile)
- [GLXY](https://www.galaxy.com/about)
- [GPGI](https://gpgi.com/)
- [GPN](https://investors.globalpayments.com/)
- [HON](https://www.honeywell.com)
- [HOOD](https://investors.robinhood.com/)
- [HUT](https://www.hut8.com/digital-infrastructure)
- [IBKR](https://www.interactivebrokers.com/en/general/about/mediaRelations/6-1-26.php)
- [ICE](https://www.ice.com/about)
- [ICL](https://www.icl-group.com/innovation/open-innovation/novel-materials/)
- [IOND](https://investors.ionicdigital.com/news-releases/news-release-details/ionic-digital-debuts-nasdaq-marking-its-first-day-trading)
- [IREN](https://www.iren.com/)
- [JCI](https://www.johnsoncontrols.com)
- [KBR](https://www.kbr.com/en/insights-news/press-release/kbrs-mission-technology-solutions-announces-golden-dome-capabilities-names-strategic-leadership-team)
- [KLAR](https://investors.klarna.com/News--Events/news/news-details/2025/Klarna-is-now-available-to-millions-of-new-businesses-in-strengthened-partnership-with-Stripe-2025-kVjOxiySwn/default.aspx)
- [LEU](https://www.centrusenergy.com)
- [LII](https://www.lennox.com)
- [LMND](https://www.sec.gov/Archives/edgar/data/1691421/000169142126000016/lmnd-20251231.htm)
- [LNN](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [MA](https://www.mastercard.com/us/en/business/payments/consumer-payments/network-processing.html)
- [MARA](https://www.mara.com/about-us)
- [MCO](https://www.moodys.com/web/en/us/capabilities/company-reference-data/datahub.html)
- [MIAX](https://ir.miaxglobal.com/)
- [MKTX](https://www.marketaxess.com/about-us)
- [MMM](https://www.3m.com)
- [MORN](https://shareholders.morningstar.com/overview/default.aspx)
- [MP](https://www.mpmaterials.com/)
- [MSCI](https://www.msci.com/discover-msci/technology-and-data)
- [MTRN](https://www.materion.com/en/markets/semiconductor)
- [NDAQ](https://www.nasdaq.com/products/fintech)
- [NU](https://nu.com/en/about)
- [NXE](https://www.nexgenenergy.ca)
- [OKLO](https://www.oklo.com)
- [OSCR](https://www.hioscar.com/about)
- [OSK](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [PCAR](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [PRLB](https://www.protolabs.com/)
- [PYPL](https://www.paypal.com/vc/webapps/mpp/about)
- [QFIN](https://ir.qfin.com/company-tear-sheet)
- [RIOT](https://www.riotplatforms.com/)
- [SEZL](https://investors.sezzle.com/)
- [SOFI](https://investors.sofi.com/overview/)
- [SPGI](https://investorfactbook.spglobal.com/sp-global-market-intelligence/how-sp-global-market-intelligence-generates-revenue/)
- [SPXC](https://www.spx.com)
- [STDN](https://www.standardnuclear.com)
- [TEX](https://stockanalysis.com/stocks/industry/farm-and-heavy-construction-machinery/)
- [TLN](https://www.talenenergy.com/plant/susquehanna-steam-electric-station/)
- [TRU](https://www.transunion.com/about-us)
- [TT](https://www.tranetechnologies.com)
- [TW](https://www.tradeweb.com/who-we-are/about-us/)
- [UPST](https://ir.upstart.com/)
- [USAR](https://www.usare.com/about/)
- [V](https://corporate.visa.com/en/about-visa/visanet.html)
- [VIRT](https://www.virtu.com/about/)
- [VST](https://vistracorp.com/documents/sustainability/reporting-year/2024/VST-sustainability-report-2024.pdf)
- [WULF](https://www.terawulf.com/about)

## Group counts

A symbol may have more than one inclusion group, so these counts can overlap.

| Inclusion group | Symbols |
| --- | ---: |
| AI, blockchain and digital infrastructure | 11 |
| Advanced materials and precision manufacturing | 9 |
| Advanced materials and specialty chemicals | 38 |
| Advertising technology and digital internet businesses | 7 |
| Aerospace, defense and related engineering | 60 |
| Agricultural biotechnology and crop science | 2 |
| Agricultural, construction and specialty vehicle engineering | 11 |
| Automobile manufacturers | 15 |
| Automotive dealerships and services | 15 |
| Automotive parts and suppliers | 32 |
| Biotechnology and biological drug discovery | 168 |
| Building controls and thermal management | 6 |
| Diagnostics, genomics and life-science research | 30 |
| Digital health and health information systems | 15 |
| Electrical equipment, batteries and energy technology | 19 |
| Environmental and water technology | 4 |
| Financial technology, digital platforms and data infrastructure | 34 |
| Gaming software | 3 |
| Industrial automation and engineering | 1 |
| Industrial automation and specialty machinery | 48 |
| Internet content and platforms | 29 |
| Internet retail and marketplaces | 18 |
| Internet streaming | 4 |
| Medical devices and medical technology | 41 |
| Medical instruments and supplies | 29 |
| Nuclear fuel and reactor technology | 5 |
| Nuclear power and energy infrastructure | 3 |
| Online travel platforms | 7 |
| Online vehicle auctions | 1 |
| Pharmaceutical research and drug manufacturing | 16 |
| Road recreational vehicles and motorcycles | 4 |
| Specialty and generic drug development/manufacturing | 34 |
| Technology | 392 |
| Telecom services | 38 |
| Truck, bus and specialty vehicle manufacturers | 5 |

## Per-symbol audit

Market caps are in US dollars. Each ticker appears once.

| Symbol | Company | Exchange | Market cap (USD) | Inclusion group(s) |
| --- | --- | --- | ---: | --- |
| A | Agilent Technologies, Inc. | NYSE | 41,423,806,518 | Diagnostics, genomics and life-science research |
| AADX | Applied Aerospace & Defense, Inc. | NYSE | 2,103,200,920 | Aerospace, defense and related engineering |
| AAOI | Applied Optoelectronics, Inc. | NASDAQ | 8,945,726,609 | Technology |
| AAON | AAON, Inc. | NASDAQ | 6,579,388,124 | Building controls and thermal management |
| AAP | Advance Auto Parts, Inc. | NYSE | 2,698,672,000 | Automotive parts and suppliers |
| AAPG | Ascentage Pharma Group International | NASDAQ | 1,471,725,906 | Biotechnology and biological drug discovery |
| AAPL | Apple Inc. | NASDAQ | 4,849,208,188,600 | Technology |
| ABBV | AbbVie Inc. | NYSE | 454,361,196,319 | Pharmaceutical research and drug manufacturing |
| ABCL | AbCellera Biologics Inc. | NASDAQ | 3,528,875,783 | Biotechnology and biological drug discovery |
| ABG | Asbury Automotive Group, Inc. | NYSE | 3,742,974,695 | Automotive dealerships and services |
| ABNB | Airbnb, Inc. | NASDAQ | 100,341,587,220 | Online travel platforms |
| ABSI | Absci Corporation | NASDAQ | 1,408,951,022 | Biotechnology and biological drug discovery |
| ABT | Abbott Laboratories | NYSE | 176,412,577,027 | Medical devices and medical technology |
| ABUS | Arbutus Biopharma Corporation | NASDAQ | 1,012,980,915 | Biotechnology and biological drug discovery |
| ABVX | ABIVAX Société Anonyme | NASDAQ | 10,247,650,611 | Biotechnology and biological drug discovery |
| ACAD | ACADIA Pharmaceuticals Inc. | NASDAQ | 4,795,262,566 | Biotechnology and biological drug discovery |
| ACHR | Archer Aviation Inc. | NYSE | 4,296,732,804 | Aerospace, defense and related engineering |
| ACIW | ACI Worldwide, Inc. | NASDAQ | 5,258,758,504 | Technology |
| ACLS | Axcelis Technologies, Inc. | NASDAQ | 3,502,887,297 | Technology |
| ACMR | ACM Research, Inc. | NASDAQ | 5,014,742,112 | Technology |
| ACN | Accenture plc | NYSE | 112,536,153,845 | Technology |
| ACVA | ACV Auctions Inc. | NYSE | 1,767,701,072 | Automotive dealerships and services |
| AD | Array Digital Infrastructure, Inc. | NYSE | 3,296,579,480 | Telecom services |
| ADBE | Adobe Inc. | NASDAQ | 100,261,425,000 | Technology |
| ADEA | Adeia Inc. | NASDAQ | 2,945,582,807 | Technology |
| ADI | Analog Devices, Inc. | NASDAQ | 183,543,706,833 | Technology |
| ADIG | ADI Global Distribution Inc. | NYSE | 1,558,703,255 | Technology |
| ADMA | ADMA Biologics, Inc. | NASDAQ | 2,067,378,596 | Biotechnology and biological drug discovery |
| ADNT | Adient plc | NYSE | 1,483,344,972 | Automotive parts and suppliers |
| ADP | Automatic Data Processing, Inc. | NASDAQ | 106,569,701,828 | Technology |
| ADPT | Adaptive Biotechnologies Corporation | NASDAQ | 3,862,219,376 | Diagnostics, genomics and life-science research |
| ADSK | Autodesk, Inc. | NASDAQ | 44,392,715,312 | Technology |
| AEHR | Aehr Test Systems, Inc. | NASDAQ | 3,088,830,411 | Technology |
| AEIS | Advanced Energy Industries, Inc. | NASDAQ | 11,504,489,465 | Electrical equipment, batteries and energy technology |
| AEVA | Aeva Technologies, Inc. | NASDAQ | 1,081,833,364 | Technology |
| AFRM | Affirm Holdings, Inc. | NASDAQ | 24,105,374,529 | Financial technology, digital platforms and data infrastructure |
| AGCO | AGCO Corporation | NYSE | 8,480,842,382 | Agricultural, construction and specialty vehicle engineering |
| AGIO | Agios Pharmaceuticals, Inc. | NASDAQ | 2,005,983,235 | Biotechnology and biological drug discovery |
| AGYS | Agilysys, Inc. | NASDAQ | 2,939,820,090 | Technology |
| AI | C3.ai, Inc. | NYSE | 1,694,619,682 | Technology |
| AIP | Arteris, Inc. | NASDAQ | 1,115,261,194 | Technology |
| AIR | AAR Corp. | NYSE | 4,942,214,507 | Aerospace, defense and related engineering |
| AKAM | Akamai Technologies, Inc. | NASDAQ | 15,347,496,675 | Technology |
| AKTS | Aktis Oncology, Inc. | NASDAQ | 1,295,934,327 | Biotechnology and biological drug discovery |
| ALAB | Astera Labs, Inc. | NASDAQ | 50,522,331,987 | Technology |
| ALB | Albemarle Corporation | NYSE | 13,867,954,299 | Advanced materials and specialty chemicals |
| ALC | Alcon Inc. | NYSE | 31,984,913,327 | Medical instruments and supplies |
| ALG | Alamo Group Inc. | NYSE | 2,057,866,762 | Agricultural, construction and specialty vehicle engineering |
| ALGM | Allegro MicroSystems, Inc. | NASDAQ | 6,768,258,290 | Technology |
| ALGN | Align Technology, Inc. | NASDAQ | 10,714,230,479 | Medical instruments and supplies |
| ALKS | Alkermes plc | NASDAQ | 7,712,077,614 | Specialty and generic drug development/manufacturing |
| ALKT | Alkami Technology, Inc. | NASDAQ | 2,182,476,484 | Technology |
| ALMR | Alamar Biosciences, Inc. | NASDAQ | 1,935,364,244 | Medical devices and medical technology |
| ALMS | Alumis Inc. | NASDAQ | 1,188,215,494 | Biotechnology and biological drug discovery |
| ALNT | Allient Inc. | NASDAQ | 1,677,467,735 | Technology |
| ALNY | Alnylam Pharmaceuticals, Inc. | NASDAQ | 33,275,651,464 | Biotechnology and biological drug discovery |
| ALRM | Alarm.com Holdings, Inc. | NASDAQ | 2,717,635,022 | Technology |
| ALSN | Allison Transmission Holdings, Inc. | NYSE | 10,482,456,144 | Automotive parts and suppliers |
| ALV | Autoliv, Inc. | NYSE | 8,871,224,095 | Automotive parts and suppliers |
| ALVO | Alvotech | NASDAQ | 1,888,066,120 | Specialty and generic drug development/manufacturing |
| AMAT | Applied Materials, Inc. | NASDAQ | 362,269,296,755 | Technology |
| AMBA | Ambarella, Inc. | NASDAQ | 2,995,406,292 | Technology |
| AMBQ | Ambiq Micro, Inc. | NYSE | 1,536,201,727 | Technology |
| AMD | Advanced Micro Devices, Inc. | NASDAQ | 842,569,343,427 | Technology |
| AME | AMETEK, Inc. | NYSE | 55,451,417,086 | Industrial automation and specialty machinery |
| AMGN | Amgen Inc. | NASDAQ | 204,007,487,087 | Pharmaceutical research and drug manufacturing |
| AMKR | Amkor Technology, Inc. | NASDAQ | 12,852,446,377 | Technology |
| AMLX | Amylyx Pharmaceuticals, Inc. | NASDAQ | 3,968,722,578 | Specialty and generic drug development/manufacturing |
| AMPH | Amphastar Pharmaceuticals, Inc. | NASDAQ | 1,011,552,308 | Specialty and generic drug development/manufacturing |
| AMPL | Amplitude, Inc. | NASDAQ | 1,572,693,271 | Technology |
| AMPX | Amprius Technologies, Inc. | NYSE | 1,379,001,034 | Electrical equipment, batteries and energy technology |
| AMRX | Amneal Pharmaceuticals, Inc. | NASDAQ | 5,924,515,249 | Specialty and generic drug development/manufacturing |
| AMSC | American Superconductor Corporation | NASDAQ | 1,430,496,483 | Industrial automation and specialty machinery |
| AMTM | Amentum Holdings, Inc. | NYSE | 4,758,094,797 | Aerospace, defense and related engineering |
| AMX | América Móvil, S.A.B. de C.V. | NYSE | 68,398,339,700 | Telecom services |
| AMZN | Amazon.com, Inc. | NASDAQ | 2,769,709,599,018 | Internet retail and marketplaces |
| AN | AutoNation, Inc. | NYSE | 6,733,494,358 | Automotive dealerships and services |
| ANAB | AnaptysBio, Inc. | NASDAQ | 1,595,008,871 | Biotechnology and biological drug discovery |
| ANET | Arista Networks, Inc. | NYSE | 251,727,827,494 | Technology |
| ANGX | Angel Studios, Inc. | NYSE | 1,017,821,939 | Internet streaming |
| ANIP | ANI Pharmaceuticals, Inc. | NASDAQ | 1,504,135,763 | Specialty and generic drug development/manufacturing |
| ANRO | Alto Neuroscience, Inc. | NYSE | 1,255,747,328 | Biotechnology and biological drug discovery |
| AORT | Artivion, Inc. | NYSE | 1,222,806,023 | Medical devices and medical technology |
| AOS | A. O. Smith Corporation | NYSE | 7,799,793,004 | Industrial automation and specialty machinery |
| APD | Air Products and Chemicals, Inc. | NYSE | 64,897,244,008 | Advanced materials and specialty chemicals |
| APH | Amphenol Corporation | NYSE | 206,943,943,423 | Technology |
| APLD | Applied Digital Corporation | NASDAQ | 7,700,613,939 | Technology |
| APMD | Apnimed, Inc. | NASDAQ | 1,091,975,333 | Biotechnology and biological drug discovery |
| APP | AppLovin Corporation | NASDAQ | 108,413,382,783 | Advertising technology and digital internet businesses |
| APPF | AppFolio, Inc. | NASDAQ | 7,383,734,492 | Technology |
| APPN | Appian Corporation | NASDAQ | 2,489,775,272 | Technology |
| APPS | Digital Turbine, Inc. | NASDAQ | 1,429,201,913 | Technology |
| APTV | Aptiv PLC | NYSE | 9,455,621,894 | Automotive parts and suppliers |
| ARGX | argenx SE | NASDAQ | 61,971,771,861 | Biotechnology and biological drug discovery |
| ARM | Arm Holdings plc | NASDAQ | 282,816,574,860 | Technology |
| ARQT | Arcutis Biotherapeutics, Inc. | NASDAQ | 3,002,152,488 | Biotechnology and biological drug discovery |
| ARW | Arrow Electronics, Inc. | NYSE | 11,616,617,529 | Technology |
| ARWR | Arrowhead Pharmaceuticals, Inc. | NASDAQ | 11,702,932,591 | Biotechnology and biological drug discovery |
| ARXS | Arxis, Inc. | NASDAQ | 22,596,841,271 | Aerospace, defense and related engineering |
| ASAN | Asana, Inc. | NYSE | 2,008,067,926 | Technology |
| ASH | Ashland Inc. | NYSE | 3,247,207,867 | Advanced materials and specialty chemicals |
| ASML | ASML Holding N.V. | NASDAQ | 658,985,480,088 | Technology |
| ASND | Ascendis Pharma A/S | NASDAQ | 17,305,895,433 | Biotechnology and biological drug discovery |
| ASTS | AST SpaceMobile, Inc. | NASDAQ | 23,295,566,191 | Technology |
| ASX | ASE Technology Holding Co., Ltd. | NYSE | 85,928,163,410 | Technology |
| ATEC | Alphatec Holdings, Inc. | NASDAQ | 1,634,092,384 | Medical devices and medical technology |
| ATEN | A10 Networks, Inc. | NYSE | 1,796,347,180 | Technology |
| ATEX | Anterix Inc. | NASDAQ | 1,611,532,213 | Telecom services |
| ATHM | Autohome Inc. | NYSE | 2,509,669,797 | Internet content and platforms |
| ATI | ATI Inc. | NYSE | 27,066,587,029 | Advanced materials and precision manufacturing |
| ATKR | Atkore Inc. | NYSE | 3,179,685,583 | Electrical equipment, batteries and energy technology |
| ATMU | Atmus Filtration Technologies Inc. | NYSE | 3,705,252,881 | Automotive parts and suppliers |
| ATR | AptarGroup, Inc. | NYSE | 7,937,468,144 | Medical instruments and supplies |
| ATRC | AtriCure, Inc. | NASDAQ | 2,774,247,675 | Medical instruments and supplies |
| ATRO | Astronics Corporation | NASDAQ | 3,181,810,555 | Aerospace, defense and related engineering |
| ATS | ATS Corporation | NYSE | 1,856,720,156 | Industrial automation and specialty machinery |
| ATTO | Attovia Therapeutics, Inc. | NASDAQ | 1,040,392,261 | Biotechnology and biological drug discovery |
| AUPH | Aurinia Pharmaceuticals Inc. | NASDAQ | 2,142,123,805 | Biotechnology and biological drug discovery |
| AUR | Aurora Innovation, Inc. | NASDAQ | 12,886,718,373 | Automotive parts and suppliers |
| AVAV | AeroVironment, Inc. | NASDAQ | 7,428,244,927 | Aerospace, defense and related engineering |
| AVBP | ArriVent BioPharma, Inc. | NASDAQ | 1,429,924,141 | Biotechnology and biological drug discovery |
| AVEX | AEVEX Corp. | NYSE | 1,833,790,536 | Aerospace, defense and related engineering |
| AVGO | Broadcom Inc. | NASDAQ | 1,728,006,274,831 | Technology |
| AVLN | Avalyn Pharma Inc. | NASDAQ | 1,488,261,999 | Biotechnology and biological drug discovery |
| AVNT | Avient Corporation | NYSE | 3,798,106,565 | Advanced materials and specialty chemicals |
| AVPT | AvePoint, Inc. | NASDAQ | 2,678,418,293 | Technology |
| AVT | Avnet, Inc. | NASDAQ | 8,176,930,898 | Technology |
| AVTR | Avantor, Inc. | NYSE | 10,016,874,420 | Medical instruments and supplies |
| AXGN | Axogen, Inc. | NASDAQ | 2,473,590,988 | Medical devices and medical technology |
| AXON | Axon Enterprise, Inc. | NASDAQ | 38,940,342,506 | Aerospace, defense and related engineering |
| AXSM | Axsome Therapeutics, Inc. | NASDAQ | 11,563,065,574 | Biotechnology and biological drug discovery |
| AXTA | Axalta Coating Systems Ltd. | NYSE | 7,310,923,098 | Advanced materials and specialty chemicals |
| AXTI | AXT, Inc. | NASDAQ | 4,157,988,651 | Technology |
| AYI | Acuity Inc. | NYSE | 9,484,450,071 | Electrical equipment, batteries and energy technology |
| AZN | AstraZeneca PLC | NYSE | 245,576,420,245 | Pharmaceutical research and drug manufacturing |
| AZO | AutoZone, Inc. | NYSE | 46,963,964,996 | Automotive parts and suppliers |
| AZTA | Azenta, Inc. | NASDAQ | 1,351,488,924 | Medical instruments and supplies |
| BA | The Boeing Company | NYSE | 166,333,370,709 | Aerospace, defense and related engineering |
| BABA | Alibaba Group Holding Limited | NYSE | 271,678,661,010 | Internet retail and marketplaces |
| BAH | Booz Allen Hamilton Holding Corporation | NYSE | 9,129,629,451 | Aerospace, defense and related engineering |
| BAND | Bandwidth Inc. | NASDAQ | 1,830,121,414 | Technology |
| BAX | Baxter International Inc. | NYSE | 12,304,504,776 | Medical instruments and supplies |
| BB | BlackBerry Limited | NYSE | 4,482,563,286 | Technology |
| BBAI | BigBear.ai Holdings, Inc. | NYSE | 1,376,149,195 | Technology |
| BBIO | BridgeBio Pharma, Inc. | NASDAQ | 14,161,512,703 | Biotechnology and biological drug discovery |
| BCAX | Bicara Therapeutics Inc. | NASDAQ | 1,509,404,625 | Biotechnology and biological drug discovery |
| BCE | BCE Inc. | NYSE | 21,772,626,236 | Telecom services |
| BCPC | Balchem Corporation | NASDAQ | 5,240,427,872 | Advanced materials and specialty chemicals |
| BCRX | BioCryst Pharmaceuticals, Inc. | NASDAQ | 2,074,945,053 | Specialty and generic drug development/manufacturing |
| BDC | Belden Inc. | NYSE | 4,777,699,632 | Technology |
| BDX | Becton, Dickinson and Company | NYSE | 48,443,992,380 | Medical instruments and supplies |
| BE | Bloom Energy Corporation | NYSE | 81,215,915,660 | Electrical equipment, batteries and energy technology |
| BEAM | Beam Therapeutics Inc. | NASDAQ | 2,397,217,543 | Biotechnology and biological drug discovery |
| BELFA | Bel Fuse Inc. | NASDAQ | 3,013,802,004 | Technology |
| BELFB | Bel Fuse Inc. | NASDAQ | 3,526,981,151 | Technology |
| BETA | BETA Technologies, Inc. | NYSE | 4,952,532,240 | Aerospace, defense and related engineering |
| BFLY | Butterfly Network, Inc. | NYSE | 1,951,870,391 | Medical devices and medical technology |
| BGC | BGC Group, Inc. | NASDAQ | 5,786,427,573 | Financial technology, digital platforms and data infrastructure |
| BGSI | Boyd Group Services Inc. | NYSE | 2,508,202,710 | Automotive dealerships and services |
| BHC | Bausch Health Companies Inc. | NYSE | 2,191,584,687 | Specialty and generic drug development/manufacturing |
| BHE | Benchmark Electronics, Inc. | NYSE | 2,794,570,787 | Technology |
| BHVN | Biohaven Ltd. | NYSE | 1,919,766,457 | Biotechnology and biological drug discovery |
| BIDU | Baidu, Inc. | NASDAQ | 31,001,648,933 | Internet content and platforms |
| BIIB | Biogen Inc. | NASDAQ | 32,084,780,666 | Pharmaceutical research and drug manufacturing |
| BILI | Bilibili Inc. | NASDAQ | 6,503,579,588 | Internet content and platforms |
| BILL | BILL Holdings, Inc. | NYSE | 4,029,327,950 | Technology |
| BIO | Bio-Rad Laboratories, Inc. | NYSE | 9,874,942,791 | Medical devices and medical technology |
| BIO.B | Bio-Rad Laboratories, Inc. | NYSE | 9,853,483,990 | Diagnostics, genomics and life-science research |
| BKNG | Booking Holdings Inc. | NASDAQ | 130,680,096,560 | Online travel platforms |
| BL | BlackLine, Inc. | NASDAQ | 1,647,851,405 | Technology |
| BLBD | Blue Bird Corporation | NASDAQ | 1,958,846,252 | Truck, bus and specialty vehicle manufacturers; Agricultural, construction and specialty vehicle engineering |
| BLCO | Bausch + Lomb Corporation | NYSE | 6,161,100,494 | Medical instruments and supplies |
| BLFS | BioLife Solutions, Inc. | NASDAQ | 1,709,289,305 | Medical instruments and supplies |
| BLKB | Blackbaud, Inc. | NASDAQ | 2,033,826,169 | Technology |
| BLLN | BillionToOne, Inc. | NASDAQ | 4,660,663,743 | Diagnostics, genomics and life-science research |
| BLSH | Bullish | NYSE | 5,325,889,912 | Technology |
| BLTE | Belite Bio, Inc | NASDAQ | 6,998,895,906 | Biotechnology and biological drug discovery |
| BMI | Badger Meter, Inc. | NYSE | 3,627,124,165 | Technology |
| BMRN | BioMarin Pharmaceutical Inc. | NASDAQ | 12,713,924,491 | Biotechnology and biological drug discovery |
| BMY | Bristol-Myers Squibb Company | NYSE | 129,998,360,708 | Pharmaceutical research and drug manufacturing |
| BNTX | BioNTech SE | NASDAQ | 24,298,998,323 | Biotechnology and biological drug discovery |
| BOX | Box, Inc. | NYSE | 4,630,526,089 | Technology |
| BR | Broadridge Financial Solutions, Inc. | NYSE | 19,126,016,397 | Technology |
| BRAI | Braiin Limited | NASDAQ | 1,170,581,135 | Technology |
| BRKR | Bruker Corporation | NASDAQ | 8,140,558,254 | Medical devices and medical technology |
| BRUN | Boost Run, Inc. | NASDAQ | 1,321,876,144 | Technology |
| BRVE | Braveheart Bio, Inc. | NASDAQ | 1,709,460,162 | Biotechnology and biological drug discovery |
| BRZE | Braze, Inc. | NASDAQ | 2,719,211,182 | Technology |
| BSP | Bending Spoons S.p.A. | NASDAQ | 23,293,817,376 | Technology |
| BSX | Boston Scientific Corporation | NYSE | 62,287,885,027 | Medical devices and medical technology |
| BSY | Bentley Systems, Incorporated | NASDAQ | 9,608,206,663 | Technology |
| BTDR | Bitdeer Technologies Group | NASDAQ | 3,250,515,650 | Technology |
| BTSG | BrightSpring Health Services, Inc. | NASDAQ | 12,234,774,787 | Digital health and health information systems |
| BULL | Webull Corporation | NASDAQ | 4,975,300,088 | Technology |
| BVS | Bioventus Inc. | NASDAQ | 1,091,512,602 | Medical devices and medical technology |
| BW | Babcock & Wilcox Enterprises, Inc. | NYSE | 1,182,782,624 | Industrial automation and specialty machinery |
| BWA | BorgWarner Inc. | NYSE | 13,574,362,494 | Automotive parts and suppliers |
| BWXT | BWX Technologies, Inc. | NYSE | 13,754,291,638 | Aerospace, defense and related engineering |
| BZ | Kanzhun Limited | NASDAQ | 7,350,246,699 | Internet content and platforms |
| CACI | CACI International Inc | NYSE | 13,727,570,641 | Technology |
| CAE | CAE Inc. | NASDAQ | 7,671,435,521 | Aerospace, defense and related engineering |
| CAI | Caris Life Sciences, Inc. | NASDAQ | 6,878,366,827 | Biotechnology and biological drug discovery |
| CALX | Calix, Inc. | NYSE | 2,218,850,972 | Technology |
| CAMT | Camtek Ltd. | NASDAQ | 6,813,201,262 | Technology |
| CARG | CarGurus, Inc. | NASDAQ | 3,066,354,480 | Internet content and platforms |
| CARR | Carrier Global Corporation | NYSE | 47,365,717,775 | Building controls and thermal management |
| CART | Maplebear Inc. | NASDAQ | 11,280,998,265 | Internet retail and marketplaces |
| CAT | Caterpillar Inc. | NYSE | 376,276,073,889 | Agricultural, construction and specialty vehicle engineering |
| CBRS | Cerebras Systems Inc. | NASDAQ | 45,595,666,389 | Technology |
| CBT | Cabot Corporation | NYSE | 4,113,958,638 | Advanced materials and specialty chemicals |
| CC | The Chemours Company | NYSE | 2,261,999,895 | Advanced materials and specialty chemicals |
| CCC | CCC Intelligent Solutions Holdings Inc. | NASDAQ | 4,058,173,511 | Technology |
| CCJ | Cameco Corporation | NYSE | 42,072,397,217 | Nuclear fuel and reactor technology |
| CDNA | CareDx, Inc. | NASDAQ | 2,600,162,048 | Diagnostics, genomics and life-science research |
| CDNS | Cadence Design Systems, Inc. | NASDAQ | 79,690,472,410 | Technology |
| CDRE | Cadre Holdings, Inc. | NYSE | 1,223,816,578 | Aerospace, defense and related engineering |
| CDW | CDW Corporation | NASDAQ | 19,226,429,945 | Technology |
| CECO | CECO Environmental Corp. | NASDAQ | 4,588,360,482 | Environmental and water technology |
| CEG | Constellation Energy Corporation | NASDAQ | 100,889,026,170 | Nuclear power and energy infrastructure |
| CELC | Celcuity Inc. | NASDAQ | 4,083,367,723 | Biotechnology and biological drug discovery |
| CERT | Certara, Inc. | NASDAQ | 1,151,667,789 | Digital health and health information systems |
| CGEM | Cullinan Therapeutics, Inc. | NASDAQ | 1,325,063,149 | Biotechnology and biological drug discovery |
| CGNX | Cognex Corporation | NASDAQ | 10,803,335,133 | Technology |
| CGON | CG Oncology, Inc. | NASDAQ | 6,413,131,131 | Biotechnology and biological drug discovery |
| CHKP | Check Point Software Technologies Ltd. | NASDAQ | 13,440,527,460 | Technology |
| CHRN | ChronoScale Holdings Corporation | NASDAQ | 2,767,111,588 | Technology |
| CHT | Chunghwa Telecom Co., Ltd. | NYSE | 34,460,643,648 | Telecom services |
| CHTR | Charter Communications, Inc. | NASDAQ | 23,841,401,417 | Telecom services |
| CHWY | Chewy, Inc. | NYSE | 8,215,392,970 | Internet retail and marketplaces |
| CHYM | Chime Financial, Inc. | NASDAQ | 12,493,308,663 | Technology |
| CIEN | Ciena Corporation | NYSE | 49,567,751,829 | Technology |
| CIFR | Cipher Digital Inc. | NASDAQ | 6,993,267,666 | Technology |
| CLBT | Cellebrite DI Ltd. | NASDAQ | 2,816,326,028 | Technology |
| CLDX | Celldex Therapeutics, Inc. | NASDAQ | 2,897,739,731 | Biotechnology and biological drug discovery |
| CLMT | Calumet, Inc. | NASDAQ | 4,992,619,691 | Advanced materials and specialty chemicals |
| CLOV | Clover Health Investments, Corp. | NASDAQ | 2,560,173,188 | Financial technology, digital platforms and data infrastructure |
| CLS | Celestica Inc. | NYSE | 39,803,244,598 | Technology |
| CLSK | CleanSpark, Inc. | NASDAQ | 3,510,689,388 | AI, blockchain and digital infrastructure |
| CLVT | Clarivate Plc | NYSE | 1,196,171,686 | Technology |
| CMCSA | Comcast Corporation | NASDAQ | 89,425,641,640 | Telecom services |
| CME | CME Group Inc. | NASDAQ | 99,078,470,127 | Financial technology, digital platforms and data infrastructure |
| CMI | Cummins Inc. | NYSE | 76,644,703,137 | Automotive parts and suppliers; Industrial automation and specialty machinery |
| CNH | CNH Industrial N.V. | NYSE | 16,808,318,510 | Agricultural, construction and specialty vehicle engineering |
| CNMD | CONMED Corporation | NYSE | 1,386,742,782 | Medical devices and medical technology |
| CNXC | Concentrix Corporation | NASDAQ | 1,723,158,204 | Technology |
| CNXN | PC Connection, Inc. | NASDAQ | 2,164,419,370 | Technology |
| COAG | Hemab Therapeutics Holdings, Inc. | NASDAQ | 1,840,457,410 | Biotechnology and biological drug discovery |
| COGT | Cogent Biosciences, Inc. | NASDAQ | 5,798,937,350 | Biotechnology and biological drug discovery |
| COHR | Coherent Corp. | NYSE | 59,801,292,961 | Technology |
| COHU | Cohu, Inc. | NASDAQ | 2,702,077,756 | Technology |
| COIN | Coinbase Global, Inc. | NASDAQ | 46,240,059,125 | AI, blockchain and digital infrastructure |
| COO | The Cooper Companies, Inc. | NASDAQ | 10,251,271,900 | Medical instruments and supplies |
| CORT | Corcept Therapeutics Incorporated | NASDAQ | 12,192,418,198 | Biotechnology and biological drug discovery |
| CORZ | Core Scientific, Inc. | NASDAQ | 5,764,847,512 | Technology |
| CPAY | Corpay, Inc. | NYSE | 26,803,561,504 | Technology |
| CPNG | Coupang, Inc. | NYSE | 27,178,376,934 | Internet retail and marketplaces |
| CPRT | Copart, Inc. | NASDAQ | 27,728,053,886 | Online vehicle auctions |
| CR | Crane Company | NYSE | 11,665,267,848 | Industrial automation and specialty machinery |
| CRCL | Circle Internet Group, Inc. | NYSE | 23,001,154,819 | AI, blockchain and digital infrastructure |
| CRCT | Cricut, Inc. | NASDAQ | 1,177,077,618 | Technology |
| CRDO | Credo Technology Group Holding Ltd | NASDAQ | 30,626,765,038 | Technology |
| CRL | Charles River Laboratories International, Inc. | NYSE | 13,283,818,523 | Diagnostics, genomics and life-science research |
| CRM | Salesforce, Inc. | NYSE | 203,873,560,000 | Technology |
| CRON | Cronos Group Inc. | NASDAQ | 1,147,248,604 | Specialty and generic drug development/manufacturing |
| CRS | Carpenter Technology Corporation | NYSE | 21,963,860,866 | Advanced materials and precision manufacturing |
| CRSP | CRISPR Therapeutics AG | NASDAQ | 5,000,944,013 | Biotechnology and biological drug discovery |
| CRSR | Corsair Gaming, Inc. | NASDAQ | 1,464,716,025 | Technology |
| CRUS | Cirrus Logic, Inc. | NASDAQ | 5,953,465,071 | Technology |
| CRVS | Corvus Pharmaceuticals, Inc. | NASDAQ | 1,086,001,387 | Biotechnology and biological drug discovery |
| CRWD | CrowdStrike Holdings, Inc. | NASDAQ | 212,142,082,915 | Technology |
| CRWV | CoreWeave, Inc. | NASDAQ | 49,081,242,212 | Technology |
| CSCO | Cisco Systems, Inc. | NASDAQ | 442,082,266,069 | Technology |
| CSQR | Csquare, Inc. | NYSE | 2,902,764,001 | Technology |
| CSW | CSW Industrials, Inc. | NYSE | 4,899,614,476 | Industrial automation and specialty machinery |
| CTS | CTS Corporation | NYSE | 1,651,975,881 | Technology |
| CTSH | Cognizant Technology Solutions Corporation | NASDAQ | 27,026,652,540 | Technology |
| CTVA | Corteva, Inc. | NYSE | 55,977,744,400 | Agricultural biotechnology and crop science |
| CVLT | Commvault Systems, Inc. | NASDAQ | 5,390,694,439 | Technology |
| CVNA | Carvana Co. | NYSE | 77,056,994,141 | Automotive dealerships and services |
| CW | Curtiss-Wright Corporation | NYSE | 20,642,660,752 | Aerospace, defense and related engineering |
| CXM | Sprinklr, Inc. | NYSE | 1,272,298,943 | Technology |
| CYD | China Yuchai International Limited | NYSE | 1,343,906,294 | Automobile manufacturers |
| CYTK | Cytokinetics, Incorporated | NASDAQ | 10,255,757,546 | Biotechnology and biological drug discovery |
| DAN | Dana Incorporated | NYSE | 3,343,483,183 | Automotive parts and suppliers |
| DASH | DoorDash, Inc. | NASDAQ | 87,504,518,377 | Internet retail and marketplaces |
| DAVE | Dave Inc. | NASDAQ | 4,473,483,860 | Technology |
| DBD | Diebold Nixdorf, Incorporated | NYSE | 2,227,575,105 | Technology |
| DBX | Dropbox, Inc. | NASDAQ | 7,732,259,532 | Technology |
| DCH | Dauch Corporation | NYSE | 1,539,677,821 | Automotive parts and suppliers |
| DCI | Donaldson Company, Inc. | NYSE | 10,345,061,748 | Industrial automation and specialty machinery |
| DCO | Ducommun Incorporated | NYSE | 2,608,184,827 | Aerospace, defense and related engineering |
| DD | DuPont de Nemours, Inc. | NYSE | 17,149,107,395 | Advanced materials and specialty chemicals |
| DDOG | Datadog, Inc. | NASDAQ | 79,430,986,059 | Technology |
| DE | Deere & Company | NYSE | 182,196,675,905 | Agricultural, construction and specialty vehicle engineering |
| DELL | Dell Technologies Inc. | NYSE | 360,690,214,948 | Technology |
| DFIN | Donnelley Financial Solutions, Inc. | NYSE | 1,178,869,115 | Technology |
| DFTX | Definium Therapeutics, Inc. | NASDAQ | 5,225,530,686 | Biotechnology and biological drug discovery |
| DGII | Digi International Inc. | NASDAQ | 2,619,558,931 | Technology |
| DGX | Quest Diagnostics Incorporated | NYSE | 25,939,947,067 | Diagnostics, genomics and life-science research |
| DHR | Danaher Corporation | NYSE | 140,695,628,848 | Diagnostics, genomics and life-science research |
| DIOD | Diodes Incorporated | NASDAQ | 4,375,372,492 | Technology |
| DJT | Trump Media & Technology Group Corp. | NASDAQ | 2,406,971,433 | Internet content and platforms |
| DLO | DLocal Limited | NASDAQ | 4,360,922,978 | Technology |
| DMRA | Damora Therapeutics, Inc. | NASDAQ | 1,734,768,084 | Biotechnology and biological drug discovery |
| DNLI | Denali Therapeutics Inc. | NASDAQ | 3,371,181,729 | Biotechnology and biological drug discovery |
| DNTH | Dianthus Therapeutics, Inc. | NASDAQ | 5,940,230,944 | Biotechnology and biological drug discovery |
| DOCN | DigitalOcean Holdings, Inc. | NYSE | 14,456,405,673 | Technology |
| DOCS | Doximity, Inc. | NYSE | 4,559,532,168 | Digital health and health information systems |
| DOCU | DocuSign, Inc. | NASDAQ | 12,270,145,974 | Technology |
| DOO | BRP Inc. | NASDAQ | 4,336,913,171 | Road recreational vehicles and motorcycles |
| DORM | Dorman Products, Inc. | NASDAQ | 3,758,713,776 | Automotive parts and suppliers |
| DOV | Dover Corporation | NYSE | 25,461,296,536 | Industrial automation and specialty machinery |
| DOX | Amdocs Limited | NASDAQ | 6,413,169,300 | Technology |
| DPC | DPC Holdings PLC | NYSE | 6,319,324,577 | Aerospace, defense and related engineering |
| DRS | Leonardo DRS, Inc. | NASDAQ | 9,626,776,946 | Aerospace, defense and related engineering |
| DRTS | Alpha Tau Medical Ltd. | NASDAQ | 1,332,363,357 | Biotechnology and biological drug discovery |
| DRVN | Driven Brands Holdings Inc. | NASDAQ | 2,004,504,764 | Automotive dealerships and services |
| DSGX | The Descartes Systems Group Inc. | NASDAQ | 6,494,751,272 | Technology |
| DT | Dynatrace, Inc. | NYSE | 14,759,338,677 | Technology |
| DUOL | Duolingo, Inc. | NASDAQ | 6,722,251,130 | Technology |
| DV | DoubleVerify Holdings, Inc. | NYSE | 2,078,373,618 | Advertising technology and digital internet businesses |
| DXC | DXC Technology Company | NYSE | 1,819,879,268 | Technology |
| DXCM | DexCom, Inc. | NASDAQ | 31,332,264,318 | Medical devices and medical technology |
| DYN | Dyne Therapeutics, Inc. | NASDAQ | 3,400,652,509 | Biotechnology and biological drug discovery |
| EBAY | eBay Inc. | NASDAQ | 47,948,750,000 | Internet retail and marketplaces |
| ECHO | EchoStar Corporation | NASDAQ | 27,056,304,543 | Telecom services |
| ECL | Ecolab Inc. | NYSE | 77,421,153,577 | Advanced materials and specialty chemicals |
| ECVT | Ecovyst Inc. | NYSE | 1,085,926,508 | Advanced materials and specialty chemicals |
| EEFT | Euronet Worldwide, Inc. | NASDAQ | 2,699,791,487 | Technology |
| EFOR | Everforth, Inc. | NYSE | 1,287,123,000 | Technology |
| EFX | Equifax Inc. | NYSE | 19,854,947,424 | Financial technology, digital platforms and data infrastructure |
| ELAN | Elanco Animal Health Incorporated | NYSE | 11,576,237,801 | Specialty and generic drug development/manufacturing |
| ELVN | Enliven Therapeutics, Inc. | NASDAQ | 3,980,067,738 | Biotechnology and biological drug discovery |
| EMBJ | Embraer S.A. | NYSE | 13,522,988,330 | Aerospace, defense and related engineering |
| EMN | Eastman Chemical Company | NYSE | 7,786,786,293 | Advanced materials and specialty chemicals |
| EMR | Emerson Electric Co. | NYSE | 84,891,582,000 | Industrial automation and specialty machinery |
| ENOV | Enovis Corporation | NYSE | 1,111,867,844 | Medical devices and medical technology |
| ENPH | Enphase Energy, Inc. | NASDAQ | 4,803,457,955 | Technology |
| ENR | Energizer Holdings, Inc. | NYSE | 1,409,393,249 | Electrical equipment, batteries and energy technology |
| ENS | EnerSys | NYSE | 6,471,904,447 | Electrical equipment, batteries and energy technology |
| ENTG | Entegris, Inc. | NASDAQ | 21,448,536,000 | Technology |
| ENVA | Enova International, Inc. | NYSE | 5,564,287,951 | Financial technology, digital platforms and data infrastructure |
| EOSE | Eos Energy Enterprises, Inc. | NASDAQ | 1,438,462,589 | Electrical equipment, batteries and energy technology |
| EPAC | Enerpac Tool Group Corp. | NYSE | 1,801,067,892 | Industrial automation and specialty machinery |
| EPAM | EPAM Systems, Inc. | NYSE | 6,082,620,930 | Technology |
| ERAS | Erasca, Inc. | NASDAQ | 5,554,221,116 | Biotechnology and biological drug discovery |
| ERIC | Telefonaktiebolaget LM Ericsson (publ) | NASDAQ | 33,444,496,561 | Technology |
| EROC | ERock, Inc. | NYSE | 3,470,916,515 | Industrial automation and specialty machinery |
| ESAB | ESAB Corporation | NYSE | 4,394,642,489 | Advanced materials and precision manufacturing |
| ESE | ESCO Technologies Inc. | NYSE | 7,002,815,360 | Technology |
| ESI | Element Solutions Inc | NYSE | 8,368,345,987 | Advanced materials and specialty chemicals |
| ESLT | Elbit Systems Ltd. | NASDAQ | 34,343,940,587 | Aerospace, defense and related engineering |
| ESTA | Establishment Labs Holdings Inc. | NASDAQ | 2,114,146,148 | Medical devices and medical technology |
| ESTC | Elastic N.V. | NYSE | 8,755,222,839 | Technology |
| ETN | Eaton Corporation plc | NYSE | 165,213,708,000 | Industrial automation and specialty machinery |
| ETON | Eton Pharmaceuticals, Inc. | NASDAQ | 1,631,525,346 | Specialty and generic drug development/manufacturing |
| ETOR | eToro Group Ltd. | NASDAQ | 2,413,647,182 | Financial technology, digital platforms and data infrastructure |
| ETSY | Etsy, Inc. | NYSE | 6,678,039,984 | Internet retail and marketplaces |
| EVCM | EverCommerce Inc. | NASDAQ | 1,114,757,702 | Technology |
| EVTC | EVERTEC, Inc. | NYSE | 1,748,956,904 | Technology |
| EW | Edwards Lifesciences Corporation | NYSE | 48,630,868,000 | Medical devices and medical technology |
| EWTX | Edgewise Therapeutics, Inc. | NASDAQ | 4,822,023,328 | Biotechnology and biological drug discovery |
| EXEL | Exelixis, Inc. | NASDAQ | 13,905,508,555 | Biotechnology and biological drug discovery |
| EXLS | ExlService Holdings, Inc. | NASDAQ | 5,345,856,715 | Technology |
| EXPE | Expedia Group, Inc. | NASDAQ | 33,705,032,095 | Online travel platforms |
| EXTR | Extreme Networks, Inc. | NASDAQ | 2,896,892,497 | Technology |
| F | Ford Motor Company | NYSE | 55,706,711,468 | Automobile manufacturers |
| FCEL | FuelCell Energy, Inc. | NASDAQ | 1,270,472,174 | Electrical equipment, batteries and energy technology |
| FDS | FactSet Research Systems Inc. | NYSE | 9,236,727,173 | Financial technology, digital platforms and data infrastructure |
| FELE | Franklin Electric Co., Inc. | NASDAQ | 4,325,207,523 | Industrial automation and specialty machinery |
| FFIV | F5, Inc. | NASDAQ | 23,313,977,101 | Technology |
| FICO | Fair Isaac Corporation | NYSE | 21,282,093,553 | Technology |
| FIG | Figma, Inc. | NYSE | 12,365,828,914 | Technology |
| FIGR | Figure Technology Solutions, Inc. | NASDAQ | 7,824,056,397 | AI, blockchain and digital infrastructure |
| FIS | Fidelity National Information Services, Inc. | NYSE | 19,669,023,674 | Technology |
| FISV | Fiserv, Inc. | NASDAQ | 27,428,527,469 | Technology |
| FIVN | Five9, Inc. | NASDAQ | 2,291,023,460 | Technology |
| FLEX | Flex Ltd. | NASDAQ | 42,769,476,793 | Technology |
| FLNC | Fluence Energy, Inc. | NASDAQ | 1,833,041,944 | Electrical equipment, batteries and energy technology |
| FLS | Flowserve Corporation | NYSE | 9,464,817,599 | Industrial automation and specialty machinery |
| FLY | Firefly Aerospace Inc. | NASDAQ | 3,537,260,149 | Aerospace, defense and related engineering |
| FLYW | Flywire Corporation | NASDAQ | 2,174,201,334 | Technology |
| FMC | FMC Corporation | NYSE | 1,427,585,965 | Agricultural biotechnology and crop science |
| FN | Fabrinet | NYSE | 14,856,417,917 | Technology |
| FOIL | Londian Wason New Energy Tech Inc. | NYSE | 1,617,098,062 | Advanced materials and precision manufacturing |
| FORM | FormFactor, Inc. | NASDAQ | 8,979,977,339 | Technology |
| FORTY | Formula Systems (1985) Ltd. | NASDAQ | 1,854,288,918 | Technology |
| FOUR | Shift4 Payments, Inc. | NYSE | 3,557,153,406 | Technology |
| FPS | Forgent Power Solutions, Inc. | NYSE | 9,686,927,248 | Electrical equipment, batteries and energy technology |
| FRNM | Freenome, Inc. | NASDAQ | 1,544,010,717 | Diagnostics, genomics and life-science research |
| FROG | JFrog Ltd. | NASDAQ | 10,749,408,293 | Technology |
| FRSH | Freshworks Inc. | NASDAQ | 3,102,347,979 | Technology |
| FSLR | First Solar, Inc. | NASDAQ | 22,464,409,786 | Technology |
| FSLY | Fastly, Inc. | NASDAQ | 3,689,388,000 | Technology |
| FSS | Federal Signal Corporation | NYSE | 6,957,522,822 | Truck, bus and specialty vehicle manufacturers; Agricultural, construction and specialty vehicle engineering |
| FTAI | FTAI Aviation Ltd. | NASDAQ | 19,109,681,351 | Aerospace, defense and related engineering |
| FTNT | Fortinet, Inc. | NASDAQ | 114,510,689,824 | Technology |
| FTRE | Fortrea Holdings Inc. | NASDAQ | 1,635,720,000 | Biotechnology and biological drug discovery |
| FTV | Fortive Corporation | NYSE | 16,517,312,574 | Technology |
| FUBO | FuboTV Inc. | NYSE | 1,259,039,046 | Internet streaming |
| FUL | H.B. Fuller Company | NYSE | 2,775,430,408 | Advanced materials and specialty chemicals |
| FUTU | Futu Holdings Limited | NASDAQ | 15,804,124,520 | Financial technology, digital platforms and data infrastructure |
| G | Genpact Limited | NYSE | 5,904,729,062 | Technology |
| GBTG | Global Business Travel Group, Inc. | NYSE | 4,941,652,771 | Online travel platforms |
| GCT | GigaCloud Technology Inc. | NASDAQ | 1,852,289,993 | Technology |
| GD | General Dynamics Corporation | NYSE | 96,146,456,180 | Aerospace, defense and related engineering |
| GDDY | GoDaddy Inc. | NYSE | 12,420,340,331 | Technology |
| GDRX | GoodRx Holdings, Inc. | NASDAQ | 1,156,482,865 | Digital health and health information systems |
| GDS | GDS Holdings Limited | NASDAQ | 6,175,638,002 | Technology |
| GE | GE Aerospace | NYSE | 335,817,482,958 | Aerospace, defense and related engineering |
| GEHC | GE HealthCare Technologies Inc. | NASDAQ | 28,876,302,090 | Medical devices and medical technology |
| GEN | Gen Digital Inc. | NASDAQ | 18,113,243,588 | Technology |
| GENB | Generate Biomedicines, Inc. | NASDAQ | 2,017,700,294 | Biotechnology and biological drug discovery |
| GENI | Genius Sports Limited | NYSE | 1,825,215,847 | Internet content and platforms |
| GEV | GE Vernova Inc. | NYSE | 254,953,147,084 | Industrial automation and specialty machinery |
| GFS | GLOBALFOUNDRIES Inc. | NASDAQ | 25,763,863,300 | Technology |
| GGG | Graco Inc. | NYSE | 12,421,858,301 | Industrial automation and specialty machinery |
| GH | Guardant Health, Inc. | NASDAQ | 21,119,793,235 | Diagnostics, genomics and life-science research |
| GHM | Graham Corporation | NYSE | 1,031,685,201 | Industrial automation and specialty machinery |
| GHRS | GH Research PLC | NASDAQ | 1,867,070,206 | Biotechnology and biological drug discovery |
| GIB | CGI Inc. | NYSE | 14,347,428,144 | Technology |
| GILD | Gilead Sciences, Inc. | NASDAQ | 178,206,354,877 | Pharmaceutical research and drug manufacturing |
| GKOS | Glaukos Corporation | NYSE | 9,860,380,463 | Medical devices and medical technology |
| GLBE | Global-E Online Ltd. | NASDAQ | 6,245,027,597 | Internet retail and marketplaces |
| GLIBA | Liberty Capital Corporation | NASDAQ | 1,039,525,094 | Telecom services |
| GLIBK | Liberty Capital Corporation | NASDAQ | 1,029,824,676 | Telecom services |
| GLOB | Globant S.A. | NYSE | 1,630,028,239 | Technology |
| GLUE | Monte Rosa Therapeutics, Inc. | NASDAQ | 1,200,359,552 | Biotechnology and biological drug discovery |
| GLW | Corning Incorporated | NYSE | 143,335,018,278 | Technology |
| GLXY | Galaxy Digital Inc. | NASDAQ | 9,537,693,796 | AI, blockchain and digital infrastructure |
| GM | General Motors Company | NYSE | 75,127,400,940 | Automobile manufacturers |
| GMAB | Genmab A/S | NASDAQ | 19,407,106,328 | Biotechnology and biological drug discovery |
| GMED | Globus Medical, Inc. | NYSE | 9,960,891,400 | Medical devices and medical technology |
| GNRC | Generac Holdings Inc. | NYSE | 11,033,599,443 | Industrial automation and specialty machinery |
| GNTX | Gentex Corporation | NASDAQ | 4,801,473,113 | Automotive parts and suppliers |
| GOOG | Alphabet Inc. | NASDAQ | 4,122,997,650,000 | Internet content and platforms |
| GOOGL | Alphabet Inc. | NASDAQ | 4,139,855,000,000 | Internet content and platforms |
| GPC | Genuine Parts Company | NYSE | 18,429,092,449 | Automotive parts and suppliers |
| GPCR | Structure Therapeutics Inc. | NASDAQ | 2,756,839,072 | Biotechnology and biological drug discovery |
| GPGI | GPGI, Inc. | NYSE | 3,855,538,091 | Advanced materials and precision manufacturing |
| GPI | Group 1 Automotive, Inc. | NYSE | 3,281,809,803 | Automotive dealerships and services |
| GPN | Global Payments Inc. | NYSE | 23,363,157,653 | Financial technology, digital platforms and data infrastructure |
| GRAB | Grab Holdings Limited | NASDAQ | 12,440,150,900 | Technology |
| GRAL | GRAIL, Inc. | NASDAQ | 3,404,907,018 | Diagnostics, genomics and life-science research |
| GRC | The Gorman-Rupp Company | NYSE | 1,966,770,796 | Industrial automation and specialty machinery |
| GRFS | Grifols, S.A. | NASDAQ | 6,795,786,890 | Pharmaceutical research and drug manufacturing |
| GRMN | Garmin Ltd. | NYSE | 54,513,626,351 | Technology |
| GRND | Grindr Inc. | NYSE | 2,655,979,181 | Technology |
| GSAT | Globalstar, Inc. | NASDAQ | 10,686,388,407 | Telecom services |
| GSK | GSK plc | NYSE | 95,940,462,126 | Pharmaceutical research and drug manufacturing |
| GT | The Goodyear Tire & Rubber Company | NASDAQ | 1,546,016,218 | Automotive parts and suppliers |
| GTES | Gates Industrial Corporation Ltd. | NYSE | 6,592,056,467 | Industrial automation and specialty machinery |
| GTLB | GitLab Inc. | NASDAQ | 7,829,238,850 | Technology |
| GTM | ZoomInfo Technologies Inc. | NASDAQ | 1,106,218,175 | Technology |
| GTX | Garrett Motion Inc. | NASDAQ | 5,150,948,095 | Automotive parts and suppliers |
| GWRE | Guidewire Software, Inc. | NYSE | 11,554,406,915 | Technology |
| HAE | Haemonetics Corporation | NYSE | 4,672,092,167 | Medical devices and medical technology |
| HALO | Halozyme Therapeutics, Inc. | NASDAQ | 12,166,985,600 | Biotechnology and biological drug discovery |
| HAWK | HawkEye 360, Inc. | NYSE | 1,596,838,498 | Aerospace, defense and related engineering |
| HAYW | Hayward Holdings, Inc. | NYSE | 2,780,887,720 | Electrical equipment, batteries and energy technology |
| HCM | HUTCHMED (China) Limited | NASDAQ | 2,256,533,161 | Specialty and generic drug development/manufacturing |
| HEI | HEICO Corporation | NYSE | 44,163,339,980 | Aerospace, defense and related engineering |
| HEI.A | HEICO Corporation | NYSE | 37,338,692,522 | Aerospace, defense and related engineering |
| HII | Huntington Ingalls Industries, Inc. | NYSE | 11,021,072,015 | Aerospace, defense and related engineering |
| HIMS | Hims & Hers Health, Inc. | NYSE | 6,418,451,992 | Specialty and generic drug development/manufacturing |
| HIMX | Himax Technologies, Inc. | NASDAQ | 2,569,293,713 | Technology |
| HLIO | Helios Technologies, Inc. | NYSE | 2,328,287,771 | Industrial automation and specialty machinery |
| HLIT | Harmonic Inc. | NASDAQ | 1,308,797,340 | Technology |
| HLN | Haleon plc | NYSE | 39,764,297,231 | Specialty and generic drug development/manufacturing |
| HMC | Honda Motor Co., Ltd. | NYSE | 42,178,740,545 | Automobile manufacturers |
| HNGE | Hinge Health, Inc. | NYSE | 7,148,718,402 | Digital health and health information systems |
| HOG | Harley-Davidson, Inc. | NYSE | 2,900,500,770 | Road recreational vehicles and motorcycles |
| HON | Honeywell International Inc. | NASDAQ | 64,135,980,424 | Industrial automation and engineering |
| HONA | Honeywell Aerospace Inc. | NASDAQ | 50,160,938,259 | Aerospace, defense and related engineering |
| HOOD | Robinhood Markets, Inc. | NASDAQ | 101,209,691,472 | Financial technology, digital platforms and data infrastructure |
| HPE | Hewlett Packard Enterprise Company | NYSE | 82,422,288,128 | Technology |
| HPQ | HP Inc. | NYSE | 31,995,543,580 | Technology |
| HQY | HealthEquity, Inc. | NASDAQ | 7,962,174,393 | Digital health and health information systems |
| HRMY | Harmony Biosciences Holdings, Inc. | NASDAQ | 2,417,975,037 | Biotechnology and biological drug discovery |
| HROW | Harrow, Inc. | NASDAQ | 1,292,581,068 | Specialty and generic drug development/manufacturing |
| HSAI | Hesai Group | NASDAQ | 2,707,977,075 | Automotive parts and suppliers |
| HTFL | HeartFlow, Inc. | NASDAQ | 4,337,246,915 | Digital health and health information systems |
| HUBB | Hubbell Incorporated | NYSE | 24,324,115,688 | Electrical equipment, batteries and energy technology |
| HUBS | HubSpot, Inc. | NYSE | 11,236,351,071 | Technology |
| HUT | Hut 8 Corp. | NASDAQ | 12,153,383,545 | AI, blockchain and digital infrastructure |
| HWKN | Hawkins, Inc. | NASDAQ | 2,589,975,766 | Advanced materials and specialty chemicals |
| HWM | Howmet Aerospace Inc. | NYSE | 91,568,789,224 | Aerospace, defense and related engineering |
| HXL | Hexcel Corporation | NYSE | 7,013,318,938 | Aerospace, defense and related engineering |
| IART | Integra LifeSciences Holdings Corporation | NASDAQ | 1,205,473,843 | Medical devices and medical technology |
| IBKR | Interactive Brokers Group, Inc. | NASDAQ | 41,397,752,484 | Financial technology, digital platforms and data infrastructure |
| IBM | International Business Machines Corporation | NYSE | 229,211,875,743 | Technology |
| IBRX | ImmunityBio, Inc. | NASDAQ | 8,383,304,919 | Biotechnology and biological drug discovery |
| ICE | Intercontinental Exchange, Inc. | NYSE | 88,363,492,254 | Financial technology, digital platforms and data infrastructure |
| ICHR | Ichor Holdings, Ltd. | NASDAQ | 2,148,000,033 | Technology |
| ICL | ICL Group Ltd | NYSE | 7,305,465,929 | Advanced materials and specialty chemicals |
| ICLR | ICON Public Limited Company | NASDAQ | 13,062,979,126 | Diagnostics, genomics and life-science research |
| ICUI | ICU Medical, Inc. | NASDAQ | 3,913,101,306 | Medical instruments and supplies |
| IDCC | InterDigital, Inc. | NASDAQ | 9,035,457,231 | Technology |
| IDT | IDT Corporation | NYSE | 1,753,482,589 | Telecom services |
| IDXX | IDEXX Laboratories, Inc. | NASDAQ | 39,760,829,245 | Diagnostics, genomics and life-science research |
| IDYA | IDEAYA Biosciences, Inc. | NASDAQ | 3,627,039,704 | Biotechnology and biological drug discovery |
| IEX | IDEX Corporation | NYSE | 16,528,737,882 | Industrial automation and specialty machinery |
| IFF | International Flavors & Fragrances Inc. | NYSE | 21,333,088,406 | Advanced materials and specialty chemicals |
| ILMN | Illumina, Inc. | NASDAQ | 31,173,950,000 | Diagnostics, genomics and life-science research |
| IMCR | Immunocore Holdings plc | NASDAQ | 1,678,854,914 | Biotechnology and biological drug discovery |
| IMNM | Immunome, Inc. | NASDAQ | 2,801,960,107 | Biotechnology and biological drug discovery |
| IMOS | ChipMOS TECHNOLOGIES INC. | NASDAQ | 1,916,609,576 | Technology |
| IMTX | Immatics N.V. | NASDAQ | 1,201,504,898 | Biotechnology and biological drug discovery |
| IMVT | Immunovant, Inc. | NASDAQ | 7,716,808,200 | Biotechnology and biological drug discovery |
| INBX | Inhibrx Biosciences, Inc. | NASDAQ | 1,608,198,708 | Biotechnology and biological drug discovery |
| INCY | Incyte Corporation | NASDAQ | 24,621,695,207 | Biotechnology and biological drug discovery |
| INDV | Indivior Pharmaceuticals, Inc. | NASDAQ | 4,070,290,754 | Specialty and generic drug development/manufacturing |
| INFQ | Infleqtion, Inc. | NYSE | 2,956,684,522 | Technology |
| INFY | Infosys Limited | NYSE | 43,987,018,385 | Technology |
| INGM | Ingram Micro Holding Corporation | NYSE | 6,354,735,455 | Technology |
| INIO | Innio N.V. | NASDAQ | 15,262,500,000 | Industrial automation and specialty machinery |
| INOD | Innodata Inc. | NASDAQ | 1,829,500,860 | Technology |
| INSM | Insmed Incorporated | NASDAQ | 28,260,750,303 | Biotechnology and biological drug discovery |
| INSP | Inspire Medical Systems, Inc. | NYSE | 2,110,457,375 | Medical devices and medical technology |
| INTA | Intapp, Inc. | NASDAQ | 2,848,510,040 | Technology |
| INTC | Intel Corporation | NASDAQ | 540,900,938,866 | Technology |
| INTU | Intuit Inc. | NASDAQ | 85,935,080,520 | Technology |
| INVA | Innoviva, Inc. | NASDAQ | 1,492,591,720 | Biotechnology and biological drug discovery |
| IOND | Ionic Digital Inc. | NASDAQ | 3,752,231,033 | AI, blockchain and digital infrastructure |
| IONQ | IonQ, Inc. | NYSE | 14,600,650,307 | Technology |
| IONS | Ionis Pharmaceuticals, Inc. | NASDAQ | 9,008,852,096 | Biotechnology and biological drug discovery |
| IOSP | Innospec Inc. | NASDAQ | 2,296,352,512 | Advanced materials and specialty chemicals |
| IOT | Samsara Inc. | NYSE | 22,475,527,921 | Technology |
| IOVA | Iovance Biotherapeutics, Inc. | NASDAQ | 3,895,554,315 | Biotechnology and biological drug discovery |
| IPGP | IPG Photonics Corporation | NASDAQ | 3,402,337,775 | Technology |
| IQMX | IQM Quantum Computers Oyj | NASDAQ | 2,013,507,283 | Technology |
| IQV | IQVIA Holdings Inc. | NYSE | 43,087,342,000 | Diagnostics, genomics and life-science research |
| IR | Ingersoll Rand Inc. | NYSE | 28,296,798,357 | Industrial automation and specialty machinery |
| IRDM | Iridium Communications Inc. | NASDAQ | 5,011,926,116 | Telecom services |
| IREN | IREN Limited | NASDAQ | 17,271,590,542 | AI, blockchain and digital infrastructure |
| IRMD | IRADIMED CORPORATION | NASDAQ | 1,051,346,400 | Medical devices and medical technology |
| IRON | Disc Medicine, Inc. | NASDAQ | 2,689,802,651 | Biotechnology and biological drug discovery |
| IRTC | iRhythm Holdings, Inc. | NASDAQ | 3,673,067,424 | Medical devices and medical technology |
| ISRG | Intuitive Surgical, Inc. | NASDAQ | 130,412,587,728 | Medical instruments and supplies |
| IT | Gartner, Inc. | NYSE | 11,340,924,600 | Technology |
| ITGR | Integer Holdings Corporation | NYSE | 4,282,998,048 | Medical devices and medical technology |
| ITRI | Itron, Inc. | NASDAQ | 4,096,250,743 | Technology |
| ITRN | Ituran Location and Control Ltd. | NASDAQ | 1,041,820,079 | Technology |
| ITT | ITT Inc. | NYSE | 18,250,656,154 | Industrial automation and specialty machinery |
| ITW | Illinois Tool Works Inc. | NYSE | 76,371,968,000 | Industrial automation and specialty machinery |
| JANX | Janux Therapeutics, Inc. | NASDAQ | 1,045,438,818 | Biotechnology and biological drug discovery |
| JAZZ | Jazz Pharmaceuticals plc | NASDAQ | 15,956,003,027 | Biotechnology and biological drug discovery |
| JBIO | Jade Biosciences, Inc. | NASDAQ | 1,137,757,253 | Biotechnology and biological drug discovery |
| JBL | Jabil Inc. | NYSE | 33,330,677,269 | Technology |
| JBTM | JBT Marel Corporation | NYSE | 5,910,817,204 | Industrial automation and specialty machinery |
| JCI | Johnson Controls International plc | NYSE | 88,444,312,035 | Building controls and thermal management |
| JD | JD.com, Inc. | NASDAQ | 36,368,640,000 | Internet retail and marketplaces |
| JKHY | Jack Henry & Associates, Inc. | NASDAQ | 11,296,543,401 | Technology |
| JNJ | Johnson & Johnson | NYSE | 640,020,869,391 | Pharmaceutical research and drug manufacturing |
| JOYY | JOYY Inc. | NASDAQ | 3,783,692,842 | Internet content and platforms |
| KAI | Kadant Inc. | NYSE | 3,144,767,857 | Industrial automation and specialty machinery |
| KARD | Kardigan, Inc. | NASDAQ | 1,731,688,505 | Biotechnology and biological drug discovery |
| KARO | Karooooo Ltd. | NASDAQ | 2,001,267,974 | Technology |
| KBR | KBR, Inc. | NYSE | 4,612,819,155 | Aerospace, defense and related engineering |
| KC | Kingsoft Cloud Holdings Limited | NASDAQ | 2,989,184,792 | Technology |
| KD | Kyndryl Holdings, Inc. | NYSE | 2,864,310,158 | Technology |
| KEEL | Keel Infrastructure Corp. | NASDAQ | 2,204,736,367 | Technology |
| KEYS | Keysight Technologies, Inc. | NYSE | 57,651,680,447 | Technology |
| KLAC | KLA Corporation | NASDAQ | 236,014,610,881 | Technology |
| KLAR | Klarna Group plc | NYSE | 5,243,783,713 | Financial technology, digital platforms and data infrastructure |
| KLIC | Kulicke and Soffa Industries, Inc. | NASDAQ | 4,507,106,675 | Technology |
| KLRA | Kailera Therapeutics, Inc. | NASDAQ | 1,807,232,843 | Biotechnology and biological drug discovery |
| KMTS | Kestra Medical Technologies, Ltd. | NASDAQ | 1,339,081,315 | Medical instruments and supplies |
| KMX | CarMax, Inc. | NYSE | 8,701,988,407 | Automotive dealerships and services |
| KN | Knowles Corporation | NYSE | 3,153,349,236 | Technology |
| KNSA | Kiniksa Pharmaceuticals International, plc | NASDAQ | 5,950,891,472 | Specialty and generic drug development/manufacturing |
| KOD | Kodiak Sciences Inc. | NASDAQ | 2,062,949,800 | Biotechnology and biological drug discovery |
| KRMN | Karman Holdings Inc. | NYSE | 4,675,789,218 | Aerospace, defense and related engineering |
| KRYS | Krystal Biotech, Inc. | NASDAQ | 10,270,796,092 | Biotechnology and biological drug discovery |
| KSPI | Joint Stock Company Kaspi.kz | NASDAQ | 18,981,823,601 | Technology |
| KT | KT Corporation | NYSE | 9,395,205,342 | Telecom services |
| KTOS | Kratos Defense & Security Solutions, Inc. | NASDAQ | 8,764,708,758 | Aerospace, defense and related engineering |
| KURA | Kura Oncology, Inc. | NASDAQ | 1,013,261,450 | Biotechnology and biological drug discovery |
| KVYO | Klaviyo, Inc. | NYSE | 4,658,140,869 | Technology |
| KWR | Quaker Chemical Corporation | NYSE | 2,688,187,206 | Advanced materials and specialty chemicals |
| KYIV | Kyivstar Group Ltd. | NASDAQ | 3,155,663,923 | Telecom services |
| KYMR | Kymera Therapeutics, Inc. | NASDAQ | 9,558,995,045 | Biotechnology and biological drug discovery |
| LAD | Lithia Motors, Inc. | NYSE | 7,870,395,190 | Automotive dealerships and services |
| LASR | nLIGHT, Inc. | NASDAQ | 2,328,953,253 | Technology |
| LBRX | LB Pharmaceuticals Inc | NASDAQ | 1,439,726,980 | Biotechnology and biological drug discovery |
| LBTYA | Liberty Global Ltd. | NASDAQ | 3,571,186,816 | Telecom services |
| LBTYB | Liberty Global Ltd. | NASDAQ | 3,551,011,555 | Telecom services |
| LBTYK | Liberty Global Ltd. | NASDAQ | 3,551,011,555 | Telecom services |
| LCID | Lucid Group, Inc. | NASDAQ | 1,662,976,143 | Automobile manufacturers |
| LCII | LCI Industries | NYSE | 2,212,833,367 | Automotive parts and suppliers |
| LDOS | Leidos Holdings, Inc. | NYSE | 16,170,926,052 | Technology |
| LEA | Lear Corporation | NYSE | 6,452,665,626 | Automotive parts and suppliers |
| LEGN | Legend Biotech Corporation | NASDAQ | 3,611,862,753 | Biotechnology and biological drug discovery |
| LEU | Centrus Energy Corp. | NYSE | 3,115,212,879 | Nuclear fuel and reactor technology |
| LFTO | Liftoff Mobile, Inc. | NASDAQ | 3,107,233,520 | Advertising technology and digital internet businesses |
| LFUS | Littelfuse, Inc. | NASDAQ | 10,979,878,328 | Technology |
| LGND | Ligand Pharmaceuticals Incorporated | NASDAQ | 5,671,082,692 | Biotechnology and biological drug discovery |
| LH | Labcorp Holdings Inc. | NYSE | 25,265,894,000 | Diagnostics, genomics and life-science research |
| LHX | L3Harris Technologies, Inc. | NYSE | 45,723,136,813 | Aerospace, defense and related engineering |
| LI | Li Auto Inc. | NASDAQ | 11,582,405,581 | Automobile manufacturers |
| LIF | Life360, Inc. | NASDAQ | 3,425,680,976 | Technology |
| LII | Lennox International Inc. | NYSE | 12,650,589,477 | Building controls and thermal management |
| LILA | Liberty Latin America Ltd. | NASDAQ | 1,726,098,616 | Telecom services |
| LILAK | Liberty Latin America Ltd. | NASDAQ | 1,710,144,714 | Telecom services |
| LIN | Linde plc | NASDAQ | 214,918,171,594 | Advanced materials and specialty chemicals |
| LITE | Lumentum Holdings Inc. | NASDAQ | 83,154,591,000 | Technology |
| LIVN | LivaNova PLC | NASDAQ | 4,307,210,377 | Medical devices and medical technology |
| LKFT | Lakefront Biotherapeutics NV | NASDAQ | 1,758,771,176 | Biotechnology and biological drug discovery |
| LKQ | LKQ Corporation | NASDAQ | 6,099,880,293 | Automotive parts and suppliers |
| LLY | Eli Lilly and Company | NYSE | 994,487,077,421 | Pharmaceutical research and drug manufacturing |
| LMAT | LeMaitre Vascular, Inc. | NASDAQ | 1,843,033,422 | Medical instruments and supplies |
| LMND | Lemonade, Inc. | NYSE | 3,823,392,781 | Financial technology, digital platforms and data infrastructure |
| LMRI | Lumexa Imaging Holdings, Inc. | NASDAQ | 1,103,901,474 | Medical devices and medical technology |
| LMT | Lockheed Martin Corporation | NYSE | 120,978,204,815 | Aerospace, defense and related engineering |
| LNN | Lindsay Corporation | NYSE | 1,183,149,770 | Agricultural, construction and specialty vehicle engineering |
| LNTH | Lantheus Holdings, Inc. | NASDAQ | 6,543,554,992 | Specialty and generic drug development/manufacturing |
| LOAR | Loar Holdings Inc. | NYSE | 6,231,220,206 | Aerospace, defense and related engineering |
| LOGI | Logitech International S.A. | NASDAQ | 14,620,367,301 | Technology |
| LPL | LG Display Co., Ltd. | NYSE | 3,301,129,650 | Technology |
| LQDA | Liquidia Corporation | NASDAQ | 5,973,823,385 | Specialty and generic drug development/manufacturing |
| LQDT | Liquidity Services, Inc. | NASDAQ | 1,331,280,449 | Internet retail and marketplaces |
| LRCX | Lam Research Corporation | NASDAQ | 373,168,948,620 | Technology |
| LSCC | Lattice Semiconductor Corporation | NASDAQ | 17,009,545,375 | Technology |
| LSPD | Lightspeed Commerce Inc. | NYSE | 1,286,219,964 | Technology |
| LTGO | Latigo Biotherapeutics, Inc. | NASDAQ | 1,468,530,536 | Biotechnology and biological drug discovery |
| LUMN | Lumen Technologies, Inc. | NYSE | 7,158,231,104 | Telecom services |
| LUNR | Intuitive Machines, Inc. | NASDAQ | 3,285,060,376 | Aerospace, defense and related engineering |
| LYB | LyondellBasell Industries N.V. | NYSE | 20,574,287,163 | Advanced materials and specialty chemicals |
| LYFT | Lyft, Inc. | NASDAQ | 5,799,236,615 | Technology |
| LYNX | Lyntris Inc. | NYSE | 1,466,541,493 | Aerospace, defense and related engineering |
| MA | Mastercard Incorporated | NYSE | 498,616,097,749 | Financial technology, digital platforms and data infrastructure |
| MANE | Veradermics, Incorporated | NYSE | 4,134,980,060 | Biotechnology and biological drug discovery |
| MANH | Manhattan Associates, Inc. | NASDAQ | 11,767,109,449 | Technology |
| MARA | MARA Holdings, Inc. | NASDAQ | 4,627,865,578 | AI, blockchain and digital infrastructure |
| MAZE | Maze Therapeutics, Inc. | NASDAQ | 1,366,509,533 | Biotechnology and biological drug discovery |
| MBGL | Mobility Global, Inc. | NYSE | 5,943,597,811 | Technology |
| MBLY | Mobileye Global Inc. | NASDAQ | 7,014,047,684 | Automotive parts and suppliers |
| MBX | MBX Biosciences, Inc. | NASDAQ | 2,842,408,866 | Biotechnology and biological drug discovery |
| MCHP | Microchip Technology Incorporated | NASDAQ | 40,291,244,872 | Technology |
| MCO | Moody's Corporation | NYSE | 82,252,308,351 | Financial technology, digital platforms and data infrastructure |
| MDA | MDA Space Ltd. | NYSE | 4,686,891,410 | Aerospace, defense and related engineering |
| MDB | MongoDB, Inc. | NASDAQ | 29,178,312,274 | Technology |
| MDGL | Madrigal Pharmaceuticals, Inc. | NASDAQ | 12,348,924,306 | Biotechnology and biological drug discovery |
| MDLN | Medline Inc. | NASDAQ | 42,767,434,715 | Medical instruments and supplies |
| MDT | Medtronic plc | NYSE | 116,350,382,474 | Medical devices and medical technology |
| MEDP | Medpace Holdings, Inc. | NASDAQ | 16,398,655,546 | Diagnostics, genomics and life-science research |
| MELI | MercadoLibre, Inc. | NASDAQ | 96,190,591,211 | Internet retail and marketplaces |
| MESO | Mesoblast Limited | NASDAQ | 2,002,352,343 | Biotechnology and biological drug discovery |
| META | Meta Platforms, Inc. | NASDAQ | 1,650,860,458,987 | Internet content and platforms |
| MFP | Midera Food Processing, Inc. | NASDAQ | 1,881,379,007 | Industrial automation and specialty machinery |
| MGA | Magna International Inc. | NYSE | 17,535,329,284 | Automotive parts and suppliers |
| MGNI | Magnite, Inc. | NASDAQ | 3,409,192,212 | Advertising technology and digital internet businesses |
| MGRT | Mega Fortune Company Limited | NASDAQ | 1,655,843,750 | Technology |
| MGTX | MeiraGTx Holdings plc | NASDAQ | 1,228,389,919 | Biotechnology and biological drug discovery |
| MIAX | Miami International Holdings, Inc. | NYSE | 4,115,105,340 | Financial technology, digital platforms and data infrastructure |
| MIDD | The Middleby Corporation | NASDAQ | 4,898,032,620 | Industrial automation and specialty machinery |
| MIR | Mirion Technologies, Inc. | NYSE | 3,979,621,599 | Industrial automation and specialty machinery |
| MIRM | Mirum Pharmaceuticals, Inc. | NASDAQ | 6,377,640,979 | Biotechnology and biological drug discovery |
| MKSI | MKS Inc. | NASDAQ | 18,074,849,429 | Technology |
| MKTX | MarketAxess Holdings Inc. | NASDAQ | 5,736,441,233 | Financial technology, digital platforms and data infrastructure |
| MLTX | MoonLake Immunotherapeutics | NASDAQ | 1,064,684,629 | Biotechnology and biological drug discovery |
| MLYS | Mineralys Therapeutics, Inc. | NASDAQ | 2,493,074,157 | Biotechnology and biological drug discovery |
| MMED | MiniMed Group, Inc. | NASDAQ | 6,330,373,448 | Medical instruments and supplies |
| MMM | 3M Company | NYSE | 85,078,727,132 | Advanced materials and specialty chemicals |
| MMSI | Merit Medical Systems, Inc. | NASDAQ | 5,156,591,871 | Medical instruments and supplies |
| MMYT | MakeMyTrip Limited | NASDAQ | 4,711,398,380 | Online travel platforms |
| MNDY | monday.com Ltd. | NASDAQ | 3,671,084,494 | Technology |
| MNKD | MannKind Corporation | NASDAQ | 1,205,777,389 | Biotechnology and biological drug discovery |
| MOD | Modine Manufacturing Company | NYSE | 10,054,235,624 | Automotive parts and suppliers |
| MOG.A | Moog Inc. | NYSE | 11,623,952,446 | Aerospace, defense and related engineering |
| MOG.B | Moog Inc. | NYSE | 11,620,498,357 | Aerospace, defense and related engineering |
| MORN | Morningstar, Inc. | NASDAQ | 7,165,842,332 | Financial technology, digital platforms and data infrastructure |
| MP | MP Materials Corp. | NYSE | 8,995,911,210 | Advanced materials and precision manufacturing |
| MPWR | Monolithic Power Systems, Inc. | NASDAQ | 60,665,067,780 | Technology |
| MQ | Marqeta, Inc. | NASDAQ | 1,699,933,959 | Technology |
| MRCY | Mercury Systems, Inc. | NASDAQ | 4,847,573,681 | Aerospace, defense and related engineering |
| MRK | Merck & Co., Inc. | NYSE | 355,100,013,857 | Pharmaceutical research and drug manufacturing |
| MRNA | Moderna, Inc. | NASDAQ | 57,477,990,939 | Biotechnology and biological drug discovery |
| MRVI | Maravai LifeSciences Holdings, Inc. | NASDAQ | 1,695,668,771 | Biotechnology and biological drug discovery |
| MRVL | Marvell Technology, Inc. | NASDAQ | 207,042,373,329 | Technology |
| MSCI | MSCI Inc. | NYSE | 40,320,147,000 | Financial technology, digital platforms and data infrastructure |
| MSFT | Microsoft Corporation | NASDAQ | 3,680,323,111,704 | Technology |
| MSI | Motorola Solutions, Inc. | NYSE | 77,146,584,214 | Technology |
| MSTR | Strategy Inc | NASDAQ | 50,322,046,608 | Technology |
| MTCH | Match Group, Inc. | NASDAQ | 9,730,666,254 | Internet content and platforms |
| MTD | Mettler-Toledo International Inc. | NYSE | 25,917,689,798 | Diagnostics, genomics and life-science research |
| MTRN | Materion Corporation | NYSE | 5,364,892,525 | Advanced materials and precision manufacturing |
| MTSI | MACOM Technology Solutions Holdings, Inc. | NASDAQ | 20,994,368,932 | Technology |
| MTX | Minerals Technologies Inc. | NYSE | 2,141,970,113 | Advanced materials and specialty chemicals |
| MU | Micron Technology, Inc. | NASDAQ | 1,101,451,964,444 | Technology |
| MWA | Mueller Water Products, Inc. | NYSE | 3,737,648,755 | Industrial automation and specialty machinery |
| MXL | MaxLinear, Inc. | NASDAQ | 6,762,991,253 | Technology |
| NAMS | NewAmsterdam Pharma Company N.V. | NASDAQ | 2,725,447,453 | Biotechnology and biological drug discovery |
| NATL | NCR Atleos Corporation | NYSE | 3,445,075,063 | Technology |
| NAVN | Navan, Inc. | NASDAQ | 5,473,828,563 | Technology |
| NBIS | Nebius Group N.V. | NASDAQ | 61,548,894,297 | Internet content and platforms |
| NBIX | Neurocrine Biosciences, Inc. | NASDAQ | 15,879,635,056 | Specialty and generic drug development/manufacturing |
| NBTX | Nanobiotix S.A. | NASDAQ | 1,845,862,426 | Biotechnology and biological drug discovery |
| NCNO | nCino, Inc. | NASDAQ | 2,246,893,698 | Technology |
| NDAQ | Nasdaq, Inc. | NASDAQ | 50,973,146,553 | Financial technology, digital platforms and data infrastructure |
| NDSN | Nordson Corporation | NASDAQ | 17,515,779,626 | Industrial automation and specialty machinery |
| NEO | NeoGenomics, Inc. | NASDAQ | 2,225,194,621 | Diagnostics, genomics and life-science research |
| NEOG | Neogen Corporation | NASDAQ | 2,568,699,868 | Medical devices and medical technology |
| NET | Cloudflare, Inc. | NYSE | 109,149,115,039 | Technology |
| NEU | NewMarket Corporation | NYSE | 8,157,947,834 | Advanced materials and specialty chemicals |
| NFLX | Netflix, Inc. | NASDAQ | 322,288,930,922 | Internet streaming |
| NGVT | Ingevity Corporation | NYSE | 2,386,171,566 | Advanced materials and specialty chemicals |
| NICE | NICE Ltd. | NASDAQ | 5,787,899,561 | Technology |
| NIO | NIO Inc. | NYSE | 9,235,020,173 | Automobile manufacturers |
| NIQ | NIQ Global Intelligence plc | NYSE | 5,262,012,614 | Technology |
| NKTR | Nektar Therapeutics | NASDAQ | 2,381,815,261 | Biotechnology and biological drug discovery |
| NN | NextNav Inc. | NASDAQ | 2,560,527,213 | Technology |
| NOC | Northrop Grumman Corporation | NYSE | 73,726,448,603 | Aerospace, defense and related engineering |
| NOK | Nokia Oyj | NYSE | 62,107,526,748 | Technology |
| NOVT | Novanta Inc. | NASDAQ | 5,542,572,371 | Technology |
| NOW | ServiceNow, Inc. | NYSE | 137,017,730,860 | Technology |
| NPK | National Presto Industries, Inc. | NYSE | 1,100,952,417 | Aerospace, defense and related engineering |
| NPO | Enpro Inc. | NYSE | 6,308,549,862 | Industrial automation and specialty machinery |
| NRIX | Nurix Therapeutics, Inc. | NASDAQ | 2,604,920,243 | Biotechnology and biological drug discovery |
| NSIT | Insight Enterprises, Inc. | NASDAQ | 4,853,419,325 | Technology |
| NTAP | NetApp, Inc. | NASDAQ | 39,142,379,316 | Technology |
| NTCT | NetScout Systems, Inc. | NASDAQ | 2,766,513,222 | Technology |
| NTES | NetEase, Inc. | NASDAQ | 74,328,472,310 | Gaming software |
| NTLA | Intellia Therapeutics, Inc. | NASDAQ | 1,645,087,376 | Biotechnology and biological drug discovery |
| NTNX | Nutanix, Inc. | NASDAQ | 17,819,527,953 | Technology |
| NTRA | Natera, Inc. | NASDAQ | 47,413,341,838 | Diagnostics, genomics and life-science research |
| NTSK | Netskope, Inc. | NASDAQ | 6,006,239,896 | Technology |
| NU | Nu Holdings Ltd. | NYSE | 70,624,668,195 | Financial technology, digital platforms and data infrastructure |
| NUVB | Nuvation Bio Inc. | NYSE | 2,131,318,024 | Biotechnology and biological drug discovery |
| NVAX | Novavax, Inc. | NASDAQ | 1,553,788,739 | Biotechnology and biological drug discovery |
| NVCR | NovoCure Limited | NASDAQ | 1,806,074,978 | Medical devices and medical technology |
| NVDA | NVIDIA Corporation | NASDAQ | 5,271,048,630,000 | Technology |
| NVMI | Nova Ltd. | NASDAQ | 11,817,226,819 | Technology |
| NVO | Novo Nordisk A/S | NYSE | 189,823,745,738 | Pharmaceutical research and drug manufacturing |
| NVS | Novartis AG | NYSE | 261,033,182,071 | Pharmaceutical research and drug manufacturing |
| NVST | Envista Holdings Corporation | NYSE | 4,103,782,465 | Medical instruments and supplies |
| NVT | nVent Electric plc | NYSE | 26,282,492,135 | Electrical equipment, batteries and energy technology |
| NVTS | Navitas Semiconductor Corporation | NASDAQ | 3,036,517,265 | Technology |
| NXE | NexGen Energy Ltd. | NYSE | 6,587,757,360 | Nuclear fuel and reactor technology |
| NXPI | NXP Semiconductors N.V. | NASDAQ | 59,667,086,852 | Technology |
| NXT | Nextpower Inc. | NASDAQ | 12,576,859,913 | Technology |
| NYAX | Nayax Ltd. | NASDAQ | 1,777,247,797 | Technology |
| OBX | Obsidian Therapeutics, Inc. | NASDAQ | 1,099,557,193 | Biotechnology and biological drug discovery |
| OCTV | Octave Intelligence plc | NASDAQ | 4,759,401,981 | Technology |
| OCUL | Ocular Therapeutix, Inc. | NASDAQ | 2,303,770,455 | Biotechnology and biological drug discovery |
| ODC | Oil-Dri Corporation of America | NYSE | 1,253,820,511 | Advanced materials and specialty chemicals |
| ODTX | Odyssey Therapeutics, Inc. | NASDAQ | 1,180,231,645 | Biotechnology and biological drug discovery |
| OGN | Organon & Co. | NYSE | 3,581,992,666 | Pharmaceutical research and drug manufacturing |
| OKLO | Oklo Inc. | NYSE | 6,737,559,283 | Nuclear fuel and reactor technology |
| OKTA | Okta, Inc. | NASDAQ | 29,107,684,512 | Technology |
| OLED | Universal Display Corporation | NASDAQ | 3,840,988,733 | Technology |
| OMCL | Omnicell, Inc. | NASDAQ | 1,495,712,046 | Digital health and health information systems |
| OMDA | Omada Health, Inc. | NASDAQ | 1,203,520,381 | Digital health and health information systems |
| OMER | Omeros Corporation | NASDAQ | 1,323,258,416 | Biotechnology and biological drug discovery |
| ON | ON Semiconductor Corporation | NASDAQ | 29,642,194,437 | Technology |
| ONC | BeOne Medicines AG | NASDAQ | 39,398,837,399 | Biotechnology and biological drug discovery |
| ONDS | Ondas Inc. | NASDAQ | 4,125,093,425 | Technology |
| ONTO | Onto Innovation Inc. | NYSE | 13,802,622,711 | Technology |
| OPK | OPKO Health, Inc. | NASDAQ | 1,171,735,313 | Diagnostics, genomics and life-science research |
| OPLN | OPENLANE, Inc. | NYSE | 4,332,294,212 | Automotive dealerships and services |
| OPRA | Opera Limited | NASDAQ | 1,627,188,127 | Internet content and platforms |
| ORCL | Oracle Corporation | NYSE | 454,407,046,080 | Technology |
| ORIC | ORIC Pharmaceuticals, Inc. | NASDAQ | 1,247,977,978 | Biotechnology and biological drug discovery |
| ORKA | Oruka Therapeutics, Inc. | NASDAQ | 6,116,451,994 | Biotechnology and biological drug discovery |
| ORLY | O'Reilly Automotive, Inc. | NASDAQ | 69,425,015,169 | Automotive parts and suppliers |
| OSCR | Oscar Health, Inc. | NYSE | 10,103,974,100 | Financial technology, digital platforms and data infrastructure |
| OSIS | OSI Systems, Inc. | NASDAQ | 3,256,784,643 | Technology |
| OSK | Oshkosh Corporation | NYSE | 9,004,742,392 | Truck, bus and specialty vehicle manufacturers; Agricultural, construction and specialty vehicle engineering |
| OTEX | Open Text Corporation | NASDAQ | 5,473,878,615 | Technology |
| OTIS | Otis Worldwide Corporation | NYSE | 26,304,251,325 | Industrial automation and specialty machinery |
| OUST | Ouster, Inc. | NASDAQ | 2,547,728,725 | Technology |
| P | Everpure, Inc. | NYSE | 32,716,251,503 | Technology |
| PAG | Penske Automotive Group, Inc. | NYSE | 14,177,270,909 | Automotive dealerships and services |
| PAGS | PagSeguro Digital Ltd. | NYSE | 2,789,537,743 | Technology |
| PAHC | Phibro Animal Health Corporation | NASDAQ | 1,446,229,099 | Specialty and generic drug development/manufacturing |
| PANW | Palo Alto Networks, Inc. | NASDAQ | 270,471,700,000 | Technology |
| PATH | UiPath, Inc. | NYSE | 7,165,886,874 | Technology |
| PATK | Patrick Industries, Inc. | NASDAQ | 2,357,480,578 | Automotive parts and suppliers |
| PAY | Paymentus Holdings, Inc. | NYSE | 4,581,684,358 | Technology |
| PAYC | Paycom Software, Inc. | NYSE | 9,694,490,864 | Technology |
| PAYO | Payoneer Global Inc. | NASDAQ | 2,412,617,952 | Technology |
| PAYP | PayPay Corporation | NASDAQ | 12,496,978,350 | Technology |
| PAYX | Paychex, Inc. | NASDAQ | 41,222,538,773 | Technology |
| PBH | Prestige Consumer Healthcare Inc. | NYSE | 2,224,233,808 | Specialty and generic drug development/manufacturing |
| PBLS | Parabilis Medicines, Inc. | NASDAQ | 4,555,905,891 | Biotechnology and biological drug discovery |
| PCAR | PACCAR Inc | NASDAQ | 64,600,770,682 | Truck, bus and specialty vehicle manufacturers; Agricultural, construction and specialty vehicle engineering |
| PCOR | Procore Technologies, Inc. | NYSE | 8,093,141,302 | Technology |
| PCRX | Pacira BioSciences, Inc. | NASDAQ | 1,010,897,429 | Specialty and generic drug development/manufacturing |
| PCT | PureCycle Technologies, Inc. | NASDAQ | 1,209,446,956 | Environmental and water technology |
| PCTY | Paylocity Holding Corporation | NASDAQ | 7,516,049,379 | Technology |
| PCVX | Vaxcyte, Inc. | NASDAQ | 8,849,449,883 | Biotechnology and biological drug discovery |
| PD | PagerDuty, Inc. | NYSE | 1,096,917,222 | Technology |
| PDD | PDD Holdings Inc. | NASDAQ | 110,754,478,708 | Internet retail and marketplaces |
| PDFS | PDF Solutions, Inc. | NASDAQ | 2,017,194,108 | Technology |
| PEGA | Pegasystems Inc. | NASDAQ | 5,958,035,207 | Technology |
| PEN | Penumbra, Inc. | NYSE | 12,515,201,052 | Medical devices and medical technology |
| PENG | Penguin Solutions, Inc. | NASDAQ | 2,621,576,481 | Technology |
| PFE | Pfizer Inc. | NYSE | 157,994,951,887 | Pharmaceutical research and drug manufacturing |
| PGEN | Precigen, Inc. | NASDAQ | 2,452,541,442 | Biotechnology and biological drug discovery |
| PGY | Pagaya Technologies Ltd. | NASDAQ | 1,666,014,085 | Technology |
| PH | Parker-Hannifin Corporation | NYSE | 119,774,086,468 | Industrial automation and specialty machinery |
| PHG | Koninklijke Philips N.V. | NYSE | 23,981,913,591 | Medical devices and medical technology |
| PHI | PLDT Inc. | NYSE | 3,936,448,502 | Telecom services |
| PHIN | PHINIA Inc. | NYSE | 2,426,906,949 | Automotive parts and suppliers |
| PHVS | Pharvaris N.V. | NASDAQ | 2,669,175,318 | Biotechnology and biological drug discovery |
| PI | Impinj, Inc. | NASDAQ | 5,402,631,307 | Technology |
| PICS | PicS N.V. | NASDAQ | 1,323,088,814 | Technology |
| PII | Polaris Inc. | NYSE | 3,329,425,189 | Road recreational vehicles and motorcycles |
| PINS | Pinterest, Inc. | NYSE | 10,788,263,164 | Internet content and platforms |
| PL | Planet Labs PBC | NYSE | 5,985,299,419 | Aerospace, defense and related engineering |
| PLAB | Photronics, Inc. | NASDAQ | 1,710,327,871 | Technology |
| PLPC | Preformed Line Products Company | NASDAQ | 2,070,560,422 | Electrical equipment, batteries and energy technology |
| PLSE | Pulse Biosciences, Inc. | NASDAQ | 3,787,943,658 | Medical instruments and supplies |
| PLTR | Palantir Technologies Inc. | NASDAQ | 401,863,469,610 | Technology |
| PLUG | Plug Power Inc. | NASDAQ | 2,934,110,084 | Electrical equipment, batteries and energy technology |
| PLUS | ePlus inc. | NASDAQ | 2,373,983,926 | Technology |
| PLXS | Plexus Corp. | NASDAQ | 6,805,346,959 | Technology |
| PNR | Pentair plc | NYSE | 9,032,315,211 | Industrial automation and specialty machinery |
| PODD | Insulet Corporation | NASDAQ | 9,151,980,100 | Medical devices and medical technology |
| POET | POET Technologies Inc. | NASDAQ | 1,375,629,594 | Technology |
| PONY | Pony AI Inc. | NASDAQ | 2,882,334,336 | Technology |
| POWI | Power Integrations, Inc. | NASDAQ | 2,921,056,019 | Technology |
| POWL | Powell Industries, Inc. | NASDAQ | 6,648,942,930 | Electrical equipment, batteries and energy technology |
| PPG | PPG Industries, Inc. | NYSE | 23,452,650,000 | Advanced materials and specialty chemicals |
| PPLI | People Incorporated | NASDAQ | 2,793,141,827 | Internet content and platforms |
| PRAX | Praxis Precision Medicines, Inc. | NASDAQ | 9,341,469,585 | Biotechnology and biological drug discovery |
| PRCT | PROCEPT BioRobotics Corporation | NASDAQ | 1,167,237,170 | Medical devices and medical technology |
| PRGO | Perrigo Company plc | NYSE | 1,895,587,887 | Specialty and generic drug development/manufacturing |
| PRGS | Progress Software Corporation | NASDAQ | 1,637,236,645 | Technology |
| PRLB | Proto Labs, Inc. | NYSE | 1,961,117,116 | Advanced materials and precision manufacturing |
| PRM | Perimeter Solutions, Inc. | NYSE | 5,165,959,290 | Advanced materials and specialty chemicals |
| PRVA | Privia Health Group, Inc. | NASDAQ | 2,608,332,507 | Digital health and health information systems |
| PSN | Parsons Corporation | NYSE | 4,886,346,776 | Technology |
| PSNL | Personalis, Inc. | NASDAQ | 1,731,225,925 | Diagnostics, genomics and life-science research |
| PSNY | Polestar Automotive Holding UK PLC | NASDAQ | 1,287,956,211 | Automobile manufacturers |
| PSQL | Pasqal Holding SA | NASDAQ | 1,694,103,654 | Technology |
| PTC | PTC Inc. | NASDAQ | 14,190,448,814 | Technology |
| PTCT | PTC Therapeutics, Inc. | NASDAQ | 5,513,420,580 | Biotechnology and biological drug discovery |
| PTGX | Protagonist Therapeutics, Inc. | NASDAQ | 9,588,473,671 | Biotechnology and biological drug discovery |
| PTRN | Pattern Group Inc. | NASDAQ | 3,556,851,734 | Internet retail and marketplaces |
| PVLA | Palvella Therapeutics, Inc. | NASDAQ | 2,163,134,143 | Biotechnology and biological drug discovery |
| PYPL | PayPal Holdings, Inc. | NASDAQ | 45,955,358,151 | Financial technology, digital platforms and data infrastructure |
| Q | Qnity Electronics, Inc. | NYSE | 26,443,959,835 | Technology |
| QBTS | D-Wave Quantum Inc. | NASDAQ | 6,256,990,874 | Technology |
| QCOM | QUALCOMM Incorporated | NASDAQ | 194,354,966,819 | Technology |
| QFIN | Qfin Holdings, Inc. | NASDAQ | 1,029,806,672 | Financial technology, digital platforms and data infrastructure |
| QGEN | Qiagen N.V. | NYSE | 8,789,026,223 | Diagnostics, genomics and life-science research |
| QLYS | Qualys, Inc. | NASDAQ | 5,198,936,750 | Technology |
| QNST | QuinStreet, Inc. | NASDAQ | 1,049,248,197 | Advertising technology and digital internet businesses |
| QNT | Quantinuum Inc. | NASDAQ | 12,909,998,202 | Technology |
| QRVO | Qorvo, Inc. | NASDAQ | 10,291,053,489 | Technology |
| QS | QuantumScape Corporation | NASDAQ | 3,268,919,317 | Automotive parts and suppliers |
| QTWO | Q2 Holdings, Inc. | NYSE | 3,796,777,379 | Technology |
| QUBT | Quantum Computing Inc. | NASDAQ | 1,808,511,419 | Technology |
| QURE | uniQure N.V. | NASDAQ | 3,087,498,998 | Biotechnology and biological drug discovery |
| RACE | Ferrari N.V. | NYSE | 79,574,155,568 | Automobile manufacturers |
| RAL | Ralliant Corporation | NYSE | 7,440,540,538 | Technology |
| RAMP | LiveRamp Holdings, Inc. | NYSE | 2,285,891,323 | Technology |
| RAPP | Rapport Therapeutics, Inc. | NASDAQ | 2,092,812,835 | Biotechnology and biological drug discovery |
| RARE | Ultragenyx Pharmaceutical Inc. | NASDAQ | 1,405,530,884 | Biotechnology and biological drug discovery |
| RBLX | Roblox Corporation | NYSE | 32,504,105,316 | Gaming software |
| RBRK | Rubrik, Inc. | NYSE | 17,962,929,119 | Technology |
| RCAT | Red Cat Holdings, Inc. | NASDAQ | 1,215,606,322 | Aerospace, defense and related engineering |
| RCI | Rogers Communications Inc. | NYSE | 19,569,743,436 | Telecom services |
| RCUS | Arcus Biosciences, Inc. | NYSE | 3,131,127,716 | Biotechnology and biological drug discovery |
| RDDT | Reddit, Inc. | NYSE | 30,354,397,383 | Internet content and platforms |
| RDNT | RadNet, Inc. | NASDAQ | 5,940,855,931 | Diagnostics, genomics and life-science research |
| RDVT | Red Violet, Inc. | NASDAQ | 1,203,844,065 | Technology |
| RDW | Redwire Corporation | NYSE | 2,643,916,065 | Aerospace, defense and related engineering |
| RDWR | Radware Ltd. | NASDAQ | 1,174,101,471 | Technology |
| RDY | Dr. Reddy's Laboratories Limited | NYSE | 10,122,892,376 | Specialty and generic drug development/manufacturing |
| REGN | Regeneron Pharmaceuticals, Inc. | NASDAQ | 78,035,674,572 | Biotechnology and biological drug discovery |
| RELY | Remitly Global, Inc. | NASDAQ | 4,654,932,347 | Technology |
| REPL | Replimune Group, Inc. | NASDAQ | 1,217,317,671 | Biotechnology and biological drug discovery |
| RGC | Regencell Bioscience Holdings Limited | NASDAQ | 2,794,474,093 | Specialty and generic drug development/manufacturing |
| RGEN | Repligen Corporation | NASDAQ | 9,322,035,877 | Medical instruments and supplies |
| RGTI | Rigetti Computing, Inc. | NASDAQ | 5,096,648,767 | Technology |
| RIOT | Riot Platforms, Inc. | NASDAQ | 8,056,809,334 | AI, blockchain and digital infrastructure |
| RIVN | Rivian Automotive, Inc. | NASDAQ | 23,209,205,899 | Automobile manufacturers |
| RKLB | Rocket Lab Corporation | NASDAQ | 37,673,040,570 | Aerospace, defense and related engineering |
| RLAY | Relay Therapeutics, Inc. | NASDAQ | 4,135,202,577 | Biotechnology and biological drug discovery |
| RMBS | Rambus Inc. | NASDAQ | 9,432,905,613 | Technology |
| RMD | ResMed Inc. | NYSE | 31,226,209,531 | Medical instruments and supplies |
| RNG | RingCentral, Inc. | NYSE | 5,755,244,685 | Technology |
| ROG | Rogers Corporation | NYSE | 2,442,244,028 | Technology |
| ROIV | Roivant Sciences Ltd. | NASDAQ | 29,485,225,472 | Biotechnology and biological drug discovery |
| ROK | Rockwell Automation, Inc. | NYSE | 47,572,142,312 | Industrial automation and specialty machinery |
| ROKU | Roku, Inc. | NASDAQ | 22,994,550,867 | Internet streaming |
| ROP | Roper Technologies, Inc. | NASDAQ | 38,424,967,566 | Technology |
| RPM | RPM International Inc. | NYSE | 12,800,966,897 | Advanced materials and specialty chemicals |
| RPRX | Royalty Pharma plc | NASDAQ | 33,700,820,566 | Biotechnology and biological drug discovery |
| RRX | Regal Rexnord Corporation | NYSE | 10,807,194,095 | Industrial automation and specialty machinery |
| RTX | RTX Corporation | NYSE | 266,424,829,906 | Aerospace, defense and related engineering |
| RUM | RUM Group Inc. | NASDAQ | 2,868,136,761 | Internet content and platforms |
| RUN | Sunrun Inc. | NASDAQ | 2,061,650,166 | Technology |
| RUSHA | Rush Enterprises, Inc. | NASDAQ | 5,639,246,349 | Automotive dealerships and services |
| RUSHB | Rush Enterprises, Inc. | NASDAQ | 5,678,521,494 | Automotive dealerships and services |
| RVLV | Revolve Group, Inc. | NYSE | 1,502,034,925 | Internet retail and marketplaces |
| RVMD | Revolution Medicines, Inc. | NASDAQ | 43,675,331,896 | Biotechnology and biological drug discovery |
| RVTY | Revvity, Inc. | NYSE | 13,871,305,508 | Diagnostics, genomics and life-science research |
| RXRX | Recursion Pharmaceuticals, Inc. | NASDAQ | 1,716,067,478 | Biotechnology and biological drug discovery |
| RYTM | Rhythm Pharmaceuticals, Inc. | NASDAQ | 7,209,501,506 | Biotechnology and biological drug discovery |
| S | SentinelOne, Inc. | NYSE | 6,873,970,061 | Technology |
| SAH | Sonic Automotive, Inc. | NYSE | 2,399,563,472 | Automotive dealerships and services |
| SAIC | Science Applications International Corporation | NASDAQ | 5,442,502,787 | Technology |
| SAIL | SailPoint, Inc. | NASDAQ | 9,842,516,553 | Technology |
| SANM | Sanmina Corporation | NASDAQ | 11,577,028,896 | Technology |
| SAP | SAP SE | NYSE | 237,457,627,573 | Technology |
| SARO | StandardAero, Inc. | NYSE | 7,815,304,883 | Aerospace, defense and related engineering |
| SCL | Stepan Company | NYSE | 1,399,642,488 | Advanced materials and specialty chemicals |
| SCSC | ScanSource, Inc. | NASDAQ | 1,172,110,230 | Technology |
| SDGR | Schrödinger, Inc. | NASDAQ | 1,422,803,045 | Digital health and health information systems |
| SE | Sea Limited | NYSE | 65,070,355,617 | Internet retail and marketplaces |
| SECZ | Securitize Corp. | NYSE | 1,416,880,426 | Technology |
| SEDG | SolarEdge Technologies, Inc. | NASDAQ | 2,133,712,941 | Technology |
| SEPN | Septerna, Inc. | NASDAQ | 1,797,529,229 | Biotechnology and biological drug discovery |
| SEZL | Sezzle Inc. | NASDAQ | 4,002,948,914 | Financial technology, digital platforms and data infrastructure |
| SHAZ | SharonAI Holdings Inc. | NASDAQ | 2,127,086,232 | Technology |
| SHC | Sotera Health Company | NASDAQ | 5,242,334,984 | Diagnostics, genomics and life-science research |
| SHLS | Shoals Technologies Group, Inc. | NASDAQ | 1,228,589,635 | Technology |
| SHOP | Shopify Inc. | NASDAQ | 165,706,872,002 | Technology |
| SHW | The Sherwin-Williams Company | NYSE | 78,024,812,257 | Advanced materials and specialty chemicals |
| SIMO | Silicon Motion Technology Corporation | NASDAQ | 9,646,100,901 | Technology |
| SITM | SiTime Corporation | NASDAQ | 19,114,954,744 | Technology |
| SKHY | SK hynix Inc. | NASDAQ | 985,269,170,033 | Technology |
| SKM | SK Telecom Co., Ltd. | NYSE | 14,448,103,831 | Telecom services |
| SLAB | Silicon Laboratories Inc. | NASDAQ | 7,351,698,451 | Technology |
| SLBT | SL Science Holding Limited | NASDAQ | 1,174,748,681 | Biotechnology and biological drug discovery |
| SLS | SELLAS Life Sciences Group, Inc. | NASDAQ | 2,331,463,210 | Biotechnology and biological drug discovery |
| SMCI | Super Micro Computer, Inc. | NASDAQ | 26,344,311,898 | Technology |
| SMMT | Summit Therapeutics Inc. | NASDAQ | 14,000,505,515 | Biotechnology and biological drug discovery |
| SMR | NuScale Power Corporation | NYSE | 3,699,917,372 | Industrial automation and specialty machinery |
| SMTC | Semtech Corporation | NASDAQ | 15,607,777,692 | Technology |
| SNAP | Snap Inc. | NYSE | 9,606,003,004 | Internet content and platforms |
| SNDK | Sandisk Corporation | NASDAQ | 239,153,475,283 | Technology |
| SNDX | Syndax Pharmaceuticals, Inc. | NASDAQ | 1,623,421,023 | Biotechnology and biological drug discovery |
| SNN | Smith & Nephew plc | NYSE | 11,472,365,286 | Medical devices and medical technology |
| SNOW | Snowflake Inc. | NYSE | 115,954,170,450 | Technology |
| SNPS | Synopsys, Inc. | NASDAQ | 76,152,570,387 | Technology |
| SNX | TD SYNNEX Corporation | NYSE | 21,525,695,626 | Technology |
| SNY | Sanofi | NASDAQ | 101,869,239,650 | Pharmaceutical research and drug manufacturing |
| SOFI | SoFi Technologies, Inc. | NASDAQ | 22,369,998,012 | Financial technology, digital platforms and data infrastructure |
| SOLS | Solstice Advanced Materials, Inc. | NASDAQ | 9,773,878,615 | Advanced materials and specialty chemicals |
| SOLV | Solventum Corporation | NYSE | 14,886,065,101 | Medical instruments and supplies |
| SONO | Sonos, Inc. | NASDAQ | 1,788,604,962 | Technology |
| SONY | Sony Group Corporation | NYSE | 138,873,727,387 | Technology |
| SOUN | SoundHound AI, Inc. | NASDAQ | 2,780,127,623 | Technology |
| SPCX | Space Exploration Technologies Corp. | NASDAQ | 2,052,346,357,916 | Aerospace, defense and related engineering |
| SPGI | S&P Global Inc. | NYSE | 121,066,666,915 | Financial technology, digital platforms and data infrastructure |
| SPOT | Spotify Technology S.A. | NYSE | 108,085,895,779 | Internet content and platforms |
| SPSC | SPS Commerce, Inc. | NASDAQ | 2,976,494,386 | Technology |
| SPTX | Seaport Therapeutics, Inc. | NASDAQ | 1,249,403,037 | Biotechnology and biological drug discovery |
| SPXC | SPX Technologies, Inc. | NYSE | 9,607,469,665 | Building controls and thermal management |
| SQM | Sociedad Química y Minera de Chile S.A. | NYSE | 19,960,370,023 | Advanced materials and specialty chemicals |
| SRAD | Sportradar Group AG | NASDAQ | 3,819,004,209 | Technology |
| SRPT | Sarepta Therapeutics, Inc. | NASDAQ | 2,160,072,579 | Biotechnology and biological drug discovery |
| SRRK | Scholar Rock Holding Corporation | NASDAQ | 6,748,122,476 | Biotechnology and biological drug discovery |
| SSL | Sasol Limited | NYSE | 9,152,323,506 | Advanced materials and specialty chemicals |
| SSNC | SS&C Technologies Holdings, Inc. | NASDAQ | 18,835,681,236 | Technology |
| ST | Sensata Technologies Holding plc | NYSE | 6,351,185,018 | Technology |
| STAA | STAAR Surgical Company | NASDAQ | 1,136,262,677 | Medical instruments and supplies |
| STDN | Standard Nuclear, Inc. | NYSE | 1,886,436,598 | Nuclear fuel and reactor technology |
| STE | STERIS plc | NYSE | 20,549,123,184 | Medical devices and medical technology |
| STLA | Stellantis N.V. | NYSE | 15,723,532,546 | Automobile manufacturers |
| STM | STMicroelectronics N.V. | NYSE | 46,256,680,038 | Technology |
| STNE | StoneCo Ltd. | NASDAQ | 2,329,015,883 | Technology |
| STOK | Stoke Therapeutics, Inc. | NASDAQ | 1,873,196,805 | Biotechnology and biological drug discovery |
| STUB | StubHub Holdings, Inc. | NYSE | 2,304,002,495 | Internet content and platforms |
| STVN | Stevanato Group S.p.A. | NYSE | 5,708,337,099 | Medical instruments and supplies |
| STX | Seagate Technology Holdings plc | NASDAQ | 188,774,858,432 | Technology |
| SUPN | Supernus Pharmaceuticals, Inc. | NASDAQ | 2,420,408,821 | Specialty and generic drug development/manufacturing |
| SVRA | Savara Inc. | NASDAQ | 1,346,931,506 | Biotechnology and biological drug discovery |
| SWKS | Skyworks Solutions, Inc. | NASDAQ | 13,294,270,290 | Technology |
| SXI | Standex International Corporation | NYSE | 3,262,196,394 | Industrial automation and specialty machinery |
| SXT | Sensient Technologies Corporation | NYSE | 5,473,577,495 | Advanced materials and specialty chemicals |
| SYK | Stryker Corporation | NYSE | 105,697,388,556 | Medical devices and medical technology |
| SYM | Symbotic Inc. | NASDAQ | 25,480,295,958 | Industrial automation and specialty machinery |
| SYNA | Synaptics Incorporated | NASDAQ | 3,950,978,796 | Technology |
| SYRE | Spyre Therapeutics, Inc. | NASDAQ | 7,988,542,837 | Biotechnology and biological drug discovery |
| T | AT&T Inc. | NYSE | 178,573,170,039 | Telecom services |
| TAK | Takeda Pharmaceutical Company Limited | NYSE | 59,645,568,668 | Specialty and generic drug development/manufacturing |
| TARS | Tarsus Pharmaceuticals, Inc. | NASDAQ | 3,480,360,413 | Biotechnology and biological drug discovery |
| TBLA | Taboola.com Ltd. | NASDAQ | 1,026,590,512 | Internet content and platforms |
| TCOM | Trip.com Group Limited | NASDAQ | 24,571,097,762 | Online travel platforms |
| TDC | Teradata Corporation | NYSE | 2,589,120,000 | Technology |
| TDG | TransDigm Group Incorporated | NYSE | 63,032,926,988 | Aerospace, defense and related engineering |
| TDOC | Teladoc Health, Inc. | NYSE | 1,119,173,569 | Digital health and health information systems |
| TDS | Telephone and Data Systems, Inc. | NYSE | 4,312,245,360 | Telecom services |
| TDY | Teledyne Technologies Incorporated | NYSE | 27,989,091,801 | Technology |
| TE | T1 Energy Inc. | NYSE | 1,357,536,780 | Electrical equipment, batteries and energy technology |
| TEAM | Atlassian Corporation | NASDAQ | 45,489,045,056 | Technology |
| TECH | Bio-Techne Corporation | NASDAQ | 11,309,731,325 | Biotechnology and biological drug discovery |
| TEL | TE Connectivity plc | NYSE | 61,365,223,807 | Technology |
| TEM | Tempus AI, Inc. | NASDAQ | 10,647,454,952 | Digital health and health information systems |
| TENB | Tenable Holdings, Inc. | NASDAQ | 3,316,314,888 | Technology |
| TEO | Telecom Argentina S.A. | NYSE | 6,037,874,192 | Telecom services |
| TER | Teradyne, Inc. | NASDAQ | 59,365,709,590 | Technology |
| TEVA | Teva Pharmaceutical Industries Limited | NYSE | 43,220,831,756 | Specialty and generic drug development/manufacturing |
| TEX | Terex Corporation | NYSE | 6,951,726,000 | Truck, bus and specialty vehicle manufacturers; Agricultural, construction and specialty vehicle engineering |
| TFX | Teleflex Incorporated | NYSE | 5,550,360,283 | Medical instruments and supplies |
| TGTX | TG Therapeutics, Inc. | NASDAQ | 7,644,195,672 | Biotechnology and biological drug discovery |
| THO | THOR Industries, Inc. | NYSE | 3,792,900,197 | Road recreational vehicles and motorcycles |
| THRM | Gentherm Incorporated | NASDAQ | 1,192,897,331 | Automotive parts and suppliers |
| TIGO | Millicom International Cellular S.A. | NASDAQ | 16,214,202,800 | Telecom services |
| TIMB | TIM S.A. | NYSE | 9,067,277,868 | Telecom services |
| TKC | Turkcell Iletisim Hizmetleri A.S. | NYSE | 4,643,571,887 | Telecom services |
| TLK | Perusahaan Perseroan (Persero) PT Telekomunikasi Indonesia Tbk | NYSE | 14,571,248,860 | Telecom services |
| TLN | Talen Energy Corporation | NASDAQ | 14,984,705,360 | Nuclear power and energy infrastructure |
| TLX | Telix Pharmaceuticals Limited | NASDAQ | 3,981,980,464 | Biotechnology and biological drug discovery |
| TM | Toyota Motor Corporation | NYSE | 233,143,352,688 | Automobile manufacturers |
| TMDX | TransMedics Group, Inc. | NASDAQ | 2,849,603,416 | Medical devices and medical technology |
| TME | Tencent Music Entertainment Group | NYSE | 13,173,401,165 | Internet content and platforms |
| TMO | Thermo Fisher Scientific Inc. | NYSE | 225,479,289,949 | Diagnostics, genomics and life-science research |
| TMUS | T-Mobile US, Inc. | NASDAQ | 195,580,215,198 | Telecom services |
| TNC | Tennant Company | NYSE | 1,171,969,088 | Industrial automation and specialty machinery |
| TNDM | Tandem Diabetes Care, Inc. | NASDAQ | 1,190,491,677 | Medical devices and medical technology |
| TNGX | Tango Therapeutics, Inc. | NASDAQ | 4,009,554,527 | Biotechnology and biological drug discovery |
| TOST | Toast, Inc. | NYSE | 18,565,360,000 | Technology |
| TRAX | First Tracks Biotherapeutics, Inc. | NASDAQ | 1,302,031,919 | Biotechnology and biological drug discovery |
| TRIP | Tripadvisor, Inc. | NASDAQ | 1,065,342,019 | Online travel platforms |
| TRLV | Trulieve Cannabis Corp. | NYSE | 2,177,912,593 | Specialty and generic drug development/manufacturing |
| TRMB | Trimble Inc. | NASDAQ | 13,445,150,036 | Technology |
| TRU | TransUnion | NYSE | 14,887,320,000 | Financial technology, digital platforms and data infrastructure |
| TRVI | Trevi Therapeutics, Inc. | NASDAQ | 2,265,365,872 | Biotechnology and biological drug discovery |
| TSAT | Telesat Corporation | NASDAQ | 3,313,164,035 | Technology |
| TSEM | Tower Semiconductor Ltd. | NASDAQ | 23,908,317,120 | Technology |
| TSHA | Taysha Gene Therapies, Inc. | NASDAQ | 1,635,684,396 | Biotechnology and biological drug discovery |
| TSLA | Tesla, Inc. | NASDAQ | 1,443,322,599,663 | Automobile manufacturers |
| TSM | Taiwan Semiconductor Manufacturing Company Limited | NYSE | 1,951,405,098,999 | Technology |
| TT | Trane Technologies plc | NYSE | 97,364,656,286 | Building controls and thermal management |
| TTAN | ServiceTitan, Inc. | NASDAQ | 5,274,864,936 | Technology |
| TTD | The Trade Desk, Inc. | NASDAQ | 6,738,081,982 | Advertising technology and digital internet businesses |
| TTMI | TTM Technologies, Inc. | NASDAQ | 13,320,310,364 | Technology |
| TTWO | Take-Two Interactive Software, Inc. | NASDAQ | 40,288,676,053 | Gaming software |
| TU | TELUS Corporation | NYSE | 14,432,230,201 | Telecom services |
| TUYA | Tuya Inc. | NYSE | 1,103,633,242 | Technology |
| TV | Grupo Televisa, S.A.B. | NYSE | 1,238,458,875 | Telecom services |
| TVTX | Travere Therapeutics, Inc. | NASDAQ | 6,237,255,796 | Biotechnology and biological drug discovery |
| TW | Tradeweb Markets Inc. | NASDAQ | 23,739,826,897 | Financial technology, digital platforms and data infrastructure |
| TWLO | Twilio Inc. | NYSE | 34,915,326,267 | Technology |
| TWST | Twist Bioscience Corporation | NASDAQ | 7,977,638,481 | Biotechnology and biological drug discovery |
| TXG | 10x Genomics, Inc. | NASDAQ | 8,936,671,213 | Medical devices and medical technology |
| TXN | Texas Instruments Incorporated | NASDAQ | 245,389,653,228 | Technology |
| TXT | Textron Inc. | NYSE | 13,930,940,277 | Aerospace, defense and related engineering |
| TYL | Tyler Technologies, Inc. | NYSE | 13,787,402,088 | Technology |
| TYRA | Tyra Biosciences, Inc. | NASDAQ | 1,314,682,966 | Biotechnology and biological drug discovery |
| U | Unity Software Inc. | NYSE | 19,346,309,495 | Technology |
| UBER | Uber Technologies, Inc. | NYSE | 146,390,283,872 | Technology |
| UCTT | Ultra Clean Holdings, Inc. | NASDAQ | 3,352,311,227 | Technology |
| UFPT | UFP Technologies, Inc. | NASDAQ | 2,152,477,583 | Medical devices and medical technology |
| UI | Ubiquiti Inc. | NYSE | 34,147,086,141 | Technology |
| UMC | United Microelectronics Corporation | NYSE | 55,870,316,509 | Technology |
| UPBD | Upbound Group, Inc. | NASDAQ | 1,067,462,106 | Technology |
| UPST | Upstart Holdings, Inc. | NASDAQ | 2,490,240,847 | Financial technology, digital platforms and data infrastructure |
| UPWK | Upwork Inc. | NASDAQ | 1,088,234,950 | Internet content and platforms |
| URGN | UroGen Pharma Ltd. | NASDAQ | 2,068,136,663 | Biotechnology and biological drug discovery |
| USAR | USA Rare Earth, Inc. | NASDAQ | 3,807,844,740 | Advanced materials and precision manufacturing |
| UTHR | United Therapeutics Corporation | NASDAQ | 21,321,391,900 | Specialty and generic drug development/manufacturing |
| V | Visa Inc. | NYSE | 680,000,238,996 | Financial technology, digital platforms and data infrastructure |
| VC | Visteon Corporation | NASDAQ | 2,694,369,649 | Automotive parts and suppliers |
| VCEL | Vericel Corporation | NASDAQ | 1,963,261,581 | Biotechnology and biological drug discovery |
| VCYT | Veracyte, Inc. | NASDAQ | 3,285,569,176 | Diagnostics, genomics and life-science research |
| VECO | Veeco Instruments Inc. | NASDAQ | 2,740,441,761 | Technology |
| VEEV | Veeva Systems Inc. | NYSE | 42,484,882,240 | Digital health and health information systems |
| VEON | VEON Ltd. | NASDAQ | 4,673,609,305 | Telecom services |
| VERA | Vera Therapeutics, Inc. | NASDAQ | 2,525,819,892 | Biotechnology and biological drug discovery |
| VERX | Vertex, Inc. | NASDAQ | 1,988,792,435 | Technology |
| VFS | VinFast Auto Ltd. | NASDAQ | 7,509,910,592 | Automobile manufacturers |
| VGNT | Versigent PLC | NYSE | 3,321,465,576 | Automotive parts and suppliers |
| VIA | Via Transportation, Inc. | NYSE | 2,099,584,591 | Technology |
| VIAV | Viavi Solutions Inc. | NASDAQ | 9,561,555,835 | Technology |
| VICR | Vicor Corporation | NASDAQ | 9,124,983,330 | Technology |
| VIPS | Vipshop Holdings Limited | NYSE | 6,899,673,321 | Internet retail and marketplaces |
| VIR | Vir Biotechnology, Inc. | NASDAQ | 1,797,073,474 | Biotechnology and biological drug discovery |
| VIRT | Virtu Financial, Inc. | NYSE | 9,445,485,815 | Financial technology, digital platforms and data infrastructure |
| VISN | Vistance Networks, Inc. | NASDAQ | 1,494,459,150 | Technology |
| VIV | Telefônica Brasil S.A. | NYSE | 18,956,456,162 | Telecom services |
| VKTX | Viking Therapeutics, Inc. | NASDAQ | 3,730,560,925 | Biotechnology and biological drug discovery |
| VLTO | Veralto Corporation | NYSE | 22,940,953,670 | Environmental and water technology |
| VNET | VNET Group, Inc. | NASDAQ | 1,802,098,100 | Technology |
| VNT | Vontier Corporation | NYSE | 4,349,384,000 | Technology |
| VOD | Vodafone Group Public Limited Company | NASDAQ | 40,088,748,577 | Telecom services |
| VOR | Vor Biopharma Inc. | NASDAQ | 1,319,319,156 | Biotechnology and biological drug discovery |
| VOYG | Voyager Technologies, Inc. | NYSE | 2,061,561,647 | Aerospace, defense and related engineering |
| VRDN | Viridian Therapeutics, Inc. | NASDAQ | 2,406,327,794 | Biotechnology and biological drug discovery |
| VRNS | Varonis Systems, Inc. | NASDAQ | 5,182,505,083 | Technology |
| VRSN | VeriSign, Inc. | NASDAQ | 26,431,713,000 | Technology |
| VRT | Vertiv Holdings Co | NYSE | 98,965,059,751 | Electrical equipment, batteries and energy technology |
| VRTX | Vertex Pharmaceuticals Incorporated | NASDAQ | 130,643,898,667 | Biotechnology and biological drug discovery |
| VSAT | Viasat, Inc. | NASDAQ | 10,236,634,241 | Technology |
| VSEC | VSE Corporation | NASDAQ | 6,137,589,019 | Aerospace, defense and related engineering |
| VSH | Vishay Intertechnology, Inc. | NYSE | 5,093,722,136 | Technology |
| VST | Vistra Corp. | NYSE | 49,801,550,234 | Nuclear power and energy infrastructure |
| VTRS | Viatris Inc. | NASDAQ | 18,963,235,165 | Specialty and generic drug development/manufacturing |
| VVV | Valvoline Inc. | NYSE | 3,897,765,070 | Automotive dealerships and services |
| VVX | V2X, Inc. | NYSE | 2,263,761,755 | Aerospace, defense and related engineering |
| VYX | NCR Voyix Corporation | NYSE | 1,180,497,628 | Technology |
| VZ | Verizon Communications Inc. | NYSE | 210,273,172,973 | Telecom services |
| W | Wayfair Inc. | NYSE | 13,500,942,660 | Internet retail and marketplaces |
| WAT | Waters Corporation | NYSE | 40,118,633,646 | Diagnostics, genomics and life-science research |
| WAY | Waystar Holding Corp. | NASDAQ | 4,500,335,324 | Digital health and health information systems |
| WB | Weibo Corporation | NASDAQ | 1,628,809,152 | Internet content and platforms |
| WBTN | WEBTOON Entertainment Inc. | NASDAQ | 1,462,965,335 | Internet content and platforms |
| WDAY | Workday, Inc. | NASDAQ | 44,753,700,000 | Technology |
| WDC | Western Digital Corporation | NASDAQ | 161,226,699,338 | Technology |
| WDFC | WD-40 Company | NASDAQ | 2,614,697,923 | Advanced materials and specialty chemicals |
| WEX | WEX Inc. | NYSE | 6,527,310,139 | Technology |
| WGS | GeneDx Holdings Corp. | NASDAQ | 2,542,818,958 | Diagnostics, genomics and life-science research |
| WIT | Wipro Limited | NYSE | 17,343,822,515 | Technology |
| WIX | Wix.com Ltd. | NASDAQ | 3,204,835,552 | Technology |
| WK | Workiva Inc. | NYSE | 3,910,368,828 | Technology |
| WLK | Westlake Corporation | NYSE | 9,049,273,564 | Advanced materials and specialty chemicals |
| WLTH | Wealthfront Corporation | NASDAQ | 1,564,773,603 | Technology |
| WOLF | Wolfspeed, Inc. | NYSE | 1,371,960,348 | Technology |
| WRBY | Warby Parker Inc. | NYSE | 3,054,355,014 | Medical instruments and supplies |
| WRD | WeRide Inc. | NASDAQ | 1,891,497,696 | Technology |
| WSE | Wise Group plc | NASDAQ | 12,310,115,285 | Technology |
| WST | West Pharmaceutical Services, Inc. | NYSE | 24,366,200,077 | Medical instruments and supplies |
| WTS | Watts Water Technologies, Inc. | NYSE | 11,885,033,461 | Industrial automation and specialty machinery |
| WULF | TeraWulf Inc. | NASDAQ | 8,352,735,653 | AI, blockchain and digital infrastructure |
| WWD | Woodward, Inc. | NASDAQ | 19,913,793,253 | Aerospace, defense and related engineering |
| XE | X-Energy, Inc. | NASDAQ | 6,067,045,992 | Industrial automation and specialty machinery |
| XENE | Xenon Pharmaceuticals Inc. | NASDAQ | 5,679,691,337 | Biotechnology and biological drug discovery |
| XERS | Xeris Biopharma Holdings, Inc. | NASDAQ | 1,358,286,280 | Specialty and generic drug development/manufacturing |
| XNCR | Xencor, Inc. | NASDAQ | 1,814,966,421 | Biotechnology and biological drug discovery |
| XNDU | Xanadu Quantum Technologies Limited | NASDAQ | 2,622,056,221 | Technology |
| XPEL | XPEL, Inc. | NASDAQ | 1,301,339,306 | Automotive parts and suppliers |
| XPEV | XPeng Inc. | NYSE | 10,086,487,294 | Automobile manufacturers |
| XRAY | DENTSPLY SIRONA Inc. | NASDAQ | 2,085,241,543 | Medical instruments and supplies |
| XYL | Xylem Inc. | NYSE | 24,973,749,412 | Industrial automation and specialty machinery |
| XYZ | Block, Inc. | NYSE | 47,882,205,231 | Technology |
| YELP | Yelp Inc. | NYSE | 1,154,729,855 | Internet content and platforms |
| YMM | Full Truck Alliance Co. Ltd. | NYSE | 8,476,737,168 | Technology |
| YOU | Clear Secure, Inc. | NYSE | 5,713,215,703 | Technology |
| YSS | York Space Systems, Inc. | NYSE | 1,082,377,927 | Aerospace, defense and related engineering |
| Z | Zillow Group, Inc. | NASDAQ | 7,343,198,254 | Internet content and platforms |
| ZBH | Zimmer Biomet Holdings, Inc. | NYSE | 17,832,066,545 | Medical devices and medical technology |
| ZBIO | Zenas BioPharma, Inc. | NASDAQ | 2,028,299,620 | Biotechnology and biological drug discovery |
| ZBRA | Zebra Technologies Corporation | NASDAQ | 16,576,235,944 | Technology |
| ZD | Ziff Davis, Inc. | NASDAQ | 1,927,626,834 | Advertising technology and digital internet businesses |
| ZETA | Zeta Global Holdings Corp. | NYSE | 7,575,590,599 | Technology |
| ZG | Zillow Group, Inc. | NASDAQ | 7,472,594,721 | Internet content and platforms |
| ZLAB | Zai Lab Limited | NASDAQ | 2,710,106,744 | Biotechnology and biological drug discovery |
| ZM | Zoom Communications, Inc. | NASDAQ | 27,885,769,260 | Technology |
| ZS | Zscaler, Inc. | NASDAQ | 26,829,020,009 | Technology |
| ZTS | Zoetis Inc. | NYSE | 30,152,926,238 | Specialty and generic drug development/manufacturing |
| ZWS | Zurn Elkay Water Solutions Corporation | NYSE | 7,659,603,999 | Environmental and water technology |
| ZYME | Zymeworks Inc. | NASDAQ | 1,861,970,484 | Biotechnology and biological drug discovery |
