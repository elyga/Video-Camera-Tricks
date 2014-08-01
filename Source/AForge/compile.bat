@Echo off

REM
REM Configuration
REM 
REM set CONF_COMPILER=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\csc.exe
set CONF_COMPILER=C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe

REM
REM Clean
REM 
del "%~dp0Release\*.dll" 1>nul 2>nul

REM
REM Compile
REM 
REM /unsafe
REM 2.1.3
REM 
%CONF_COMPILER% /target:library /out:AForge.dll /unsafe                                                            "Core\DoublePoint.cs" Core\DoubleRange.cs Core\Exceptions.cs Core\IntPoint.cs Core\IntRange.cs Core\Parallel.cs Core\PolishExpression.cs Core\SystemTools.cs Core\Properties\AssemblyInfo.cs
%CONF_COMPILER% /target:library /out:AForge.Math.dll  /reference:AForge.dll                                        "Math\Complex.cs" Math\ContinuousHistogram.cs Math\FourierTransform.cs Math\Gaussian.cs Math\Geometry\ClosePointsMergingOptimizer.cs Math\Geometry\FlatAnglesOptimizer.cs Math\Geometry\GrahamConvexHull.cs Math\Geometry\IConvexHullAlgorithm.cs Math\Geometry\IShapeOptimizer.cs Math\Geometry\LineStraighteningOptimizer.cs Math\Geometry\PointsCloud.cs Math\Geometry\ShapeType.cs Math\Geometry\SimpleShapeChecker.cs Math\Geometry\Tools.cs Math\Histogram.cs Math\PerlinNoise.cs Math\Properties\AssemblyInfo.cs Math\Random\ExponentialGenerator.cs Math\Random\GaussianGenerator.cs Math\Random\IRandomNumberGenerator.cs Math\Random\StandardGenerator.cs Math\Random\UniformGenerator.cs Math\Random\UniformOneGenerator.cs Math\Statistics.cs Math\Tools.cs
%CONF_COMPILER% /target:library /out:AForge.Video.dll                                                              "Video\Properties\AssemblyInfo.cs" Video\ByteArrayUtils.cs Video\IVideoSource.cs Video\JPEGStream.cs Video\MJPEGStream.cs Video\VideoEvents.cs
%CONF_COMPILER% /target:library /reference:AForge.Video.dll /out:AForge.Video.DirectShow.dll                       "Video.DirectShow\Properties\AssemblyInfo.cs" Video.DirectShow\Internals\IAMStreamConfig.cs Video.DirectShow\Internals\IBaseFilter.cs Video.DirectShow\Internals\ICaptureGraphBuilder2.cs Video.DirectShow\Internals\ICreateDevEnum.cs Video.DirectShow\Internals\IEnumFilters.cs Video.DirectShow\Internals\IEnumPins.cs Video.DirectShow\Internals\IFileSourceFilter.cs Video.DirectShow\Internals\IFilterGraph2.cs Video.DirectShow\Internals\IFilterGraph.cs Video.DirectShow\Internals\IGraphBuilder.cs Video.DirectShow\Internals\IMediaControl.cs Video.DirectShow\Internals\IMediaEventEx.cs Video.DirectShow\Internals\IMediaFilter.cs Video.DirectShow\Internals\IPersist.cs Video.DirectShow\Internals\IPin.cs Video.DirectShow\Internals\IPropertyBag.cs Video.DirectShow\Internals\IReferenceClock.cs Video.DirectShow\Internals\ISampleGrabber.cs Video.DirectShow\Internals\ISampleGrabberCB.cs Video.DirectShow\Internals\ISpecifyPropertyPages.cs Video.DirectShow\Internals\IVideoWindow.cs Video.DirectShow\Internals\Structures.cs Video.DirectShow\Internals\Tools.cs Video.DirectShow\Internals\Uuids.cs Video.DirectShow\Internals\Win32.cs Video.DirectShow\FileVideoSource.cs Video.DirectShow\FilterInfo.cs Video.DirectShow\FilterInfoCollection.cs Video.DirectShow\Uuids.cs Video.DirectShow\VideoCapabilities.cs Video.DirectShow\VideoCaptureDevice.cs 
%CONF_COMPILER% /target:library /reference:AForge.Math.dll /reference:AForge.dll /out:AForge.Imaging.dll /unsafe   "Imaging\Blob.cs" "Imaging\BlobCounter.cs" "Imaging\BlobCounterBase.cs" "Imaging\BlockMatch.cs" "Imaging\ColorConverter.cs" "Imaging\Complex Filters\FrequencyFilter.cs" "Imaging\Complex Filters\IComplexFilter.cs" "Imaging\ComplexImage.cs" "Imaging\DocumentSkewChecker.cs" "Imaging\Drawing.cs" "Imaging\Exceptions.cs" "Imaging\ExhaustiveBlockMatching.cs" "Imaging\ExhaustiveTemplateMatching.cs" "Imaging\Filters\2 Source filters\Add.cs" "Imaging\Filters\2 Source filters\Difference.cs" "Imaging\Filters\2 Source filters\Intersect.cs" "Imaging\Filters\2 Source filters\Merge.cs" "Imaging\Filters\2 Source filters\Morph.cs" "Imaging\Filters\2 Source filters\MoveTowards.cs" "Imaging\Filters\2 Source filters\StereoAnaglyph.cs" "Imaging\Filters\2 Source filters\Subtract.cs" "Imaging\Filters\Adaptive Binarization\IterativeThreshold.cs" "Imaging\Filters\Adaptive Binarization\OtsuThreshold.cs" "Imaging\Filters\Adaptive Binarization\SISThreshold.cs" "Imaging\Filters\Base classes\BaseFilter.cs" "Imaging\Filters\Base classes\BaseInPlaceFilter.cs" "Imaging\Filters\Base classes\BaseInPlacePartialFilter.cs" "Imaging\Filters\Base classes\BaseInPlaceFilter2.cs" "Imaging\Filters\Base classes\BaseQuadrilateralTransformationFilter.cs" "Imaging\Filters\Base classes\BaseResizeFilter.cs" "Imaging\Filters\Base classes\BaseRotateFilter.cs" "Imaging\Filters\Base classes\BaseTransformationFilter.cs" "Imaging\Filters\Base classes\BaseUsingCopyPartialFilter.cs" "Imaging\Filters\Binarization\BayerDithering.cs" "Imaging\Filters\Binarization\BurkesDithering.cs" "Imaging\Filters\Binarization\ErrorDiffusionDithering.cs" "Imaging\Filters\Binarization\ErrorDiffusionToAdjacentNeighbors.cs" "Imaging\Filters\Binarization\FloydSteinbergDithering.cs" "Imaging\Filters\Binarization\JarvisJudiceNinkeDithering.cs" "Imaging\Filters\Binarization\OrderedDithering.cs" "Imaging\Filters\Binarization\SierraDithering.cs" "Imaging\Filters\Binarization\StuckiDithering.cs" "Imaging\Filters\Binarization\Threshold.cs" "Imaging\Filters\Binarization\ThresholdWithCarry.cs" "Imaging\Filters\Color Filters\ChannelFiltering.cs" "Imaging\Filters\Color Filters\ColorFiltering.cs" "Imaging\Filters\Color Filters\ColorRemapping.cs" "Imaging\Filters\Color Filters\ContrastStretch.cs" "Imaging\Filters\Color Filters\EuclideanColorFiltering.cs" "Imaging\Filters\Color Filters\ExtractChannel.cs" "Imaging\Filters\Color Filters\GammaCorrection.cs" "Imaging\Filters\Color Filters\Grayscale.cs" "Imaging\Filters\Color Filters\GrayscaleBT709.cs" "Imaging\Filters\Color Filters\GrayscaleRMY.cs" "Imaging\Filters\Color Filters\GrayscaleToRGB.cs" "Imaging\Filters\Color Filters\GrayscaleY.cs" "Imaging\Filters\Color Filters\HistogramEqualization.cs" "Imaging\Filters\Color Filters\Invert.cs" "Imaging\Filters\Color Filters\LevelsLinear.cs" "Imaging\Filters\Color Filters\LevelsLinear16bpp.cs" "Imaging\Filters\Color Filters\ReplaceChannel.cs" "Imaging\Filters\Color Filters\RotateChannels.cs" "Imaging\Filters\Color Filters\Sepia.cs" "Imaging\Filters\Color Segmentation\SimplePosterization.cs" "Imaging\Filters\Convolution\Blur.cs" "Imaging\Filters\Convolution\Convolution.cs" "Imaging\Filters\Convolution\Edges.cs" "Imaging\Filters\Convolution\GaussianBlur.cs" "Imaging\Filters\Convolution\Mean.cs" "Imaging\Filters\Convolution\Sharpen.cs" "Imaging\Filters\Convolution\SharpenEx.cs" "Imaging\Filters\Edge Detectors\CannyEdgeDetector.cs" "Imaging\Filters\Edge Detectors\DifferenceEdgeDetector.cs" "Imaging\Filters\Edge Detectors\HomogenityEdgeDetector.cs" "Imaging\Filters\Edge Detectors\SobelEdgeDetector.cs" "Imaging\Filters\FilterIterator.cs" "Imaging\Filters\FiltersSequence.cs" "Imaging\Filters\Flood Fillers\PointedMeanFloodFill.cs" "Imaging\Filters\HSL Filters\BrightnessCorrection.cs" "Imaging\Filters\HSL Filters\ContrastCorrection.cs" "Imaging\Filters\HSL Filters\HSLFiltering.cs" "Imaging\Filters\HSL Filters\HSLLinear.cs" "Imaging\Filters\HSL Filters\HueModifier.cs" "Imaging\Filters\HSL Filters\SaturationCorrection.cs" "Imaging\Filters\IFilter.cs" "Imaging\Filters\IFilterInformation.cs" "Imaging\Filters\IInPlaceFilter.cs" "Imaging\Filters\IInPlacePartialFilter.cs" "Imaging\Filters\IlluminationCorrection\FlatFieldCorrection.cs" "Imaging\Filters\Morphology\BottomHat.cs" "Imaging\Filters\Morphology\Closing.cs" "Imaging\Filters\Morphology\Dilatation.cs" "Imaging\Filters\Morphology\Erosion.cs" "Imaging\Filters\Morphology\HitAndMiss.cs" "Imaging\Filters\Morphology\Opening.cs" "Imaging\Filters\Morphology\Specific Optimizations\BinaryDilatation3x3.cs" "Imaging\Filters\Morphology\Specific Optimizations\BinaryErosion3x3.cs" "Imaging\Filters\Morphology\Specific Optimizations\Dilatation3x3.cs" "Imaging\Filters\Morphology\Specific Optimizations\Erosion3.x3.cs" "Imaging\Filters\Morphology\TopHat.cs" "Imaging\Filters\Noise generation\AdditiveNoise.cs" "Imaging\Filters\Noise generation\SaltAndPepperNoise.cs" "Imaging\Filters\Normalized RGB\ExtractNormalizedRGBChannel.cs" "Imaging\Filters\Other\BlobsFiltering.cs" "Imaging\Filters\Other\CanvasCrop.cs" "Imaging\Filters\Other\CanvasFill.cs" "Imaging\Filters\Other\CanvasMove.cs" "Imaging\Filters\Other\ConnectedComponentsLabeling.cs" "Imaging\Filters\Other\CornersMarker.cs" "Imaging\Filters\Other\ExtractBiggestBlob.cs" "Imaging\Filters\Other\ImageWarp.cs" "Imaging\Filters\Other\Jitter.cs" "Imaging\Filters\Other\Mirror.cs" "Imaging\Filters\Other\OilPainting.cs" "Imaging\Filters\Other\Pixellate.cs" "Imaging\Filters\Flood Fillers\PointedColorFloodFill.cs" "Imaging\Filters\Other\SimpleSkeletonization.cs" "Imaging\Filters\Other\TexturedFilter.cs" "Imaging\Filters\Other\TexturedMerge.cs" "Imaging\Filters\Other\Texturer.cs" "Imaging\Filters\Other\WaterWave.cs" "Imaging\Filters\Smooting\AdaptiveSmooth.cs" "Imaging\Filters\Smooting\ConservativeSmoothing.cs" "Imaging\Filters\Smooting\Median.cs" "Imaging\Filters\Transform\Crop.cs" "Imaging\Filters\Transform\QuadrilateralTransformationBilinear.cs" "Imaging\Filters\Transform\QuadrilateralTransformationNearestNeighbor.cs" "Imaging\Filters\Transform\ResizeBicubic.cs" "Imaging\Filters\Transform\ResizeBilinear.cs" "Imaging\Filters\Transform\ResizeNearestNeighbor.cs" "Imaging\Filters\Transform\RotateBicubic.cs" "Imaging\Filters\Transform\RotateBilinear.cs" "Imaging\Filters\Transform\RotateNearestNeighbor.cs" "Imaging\Filters\Transform\Shrink.cs" "Imaging\Filters\YCbCr Filters\YCbCrExtractChannel.cs" "Imaging\Filters\YCbCr Filters\YCbCrFiltering.cs" "Imaging\Filters\YCbCr Filters\YCbCrLinear.cs" "Imaging\Filters\YCbCr Filters\YCbCrReplaceChannel.cs" "Imaging\HorizontalIntensityStatistics.cs" "Imaging\HoughCircleTransformation.cs" "Imaging\HoughLineTransformation.cs" "Imaging\IBlockMatching.cs" "Imaging\ICornersDetector.cs" "Imaging\Image.cs" "Imaging\ImageStatistics.cs" "Imaging\ImageStatisticsHSL.cs" "Imaging\ImageStatisticsYCbCr.cs" "Imaging\IntegralImage.cs" "Imaging\Interpolation.cs" "Imaging\ITemplateMatching.cs" "Imaging\MemoryManager.cs" "Imaging\MoravecCornersDetector.cs" "Imaging\Properties\AssemblyInfo.cs" "Imaging\QuadrilateralFinder.cs" "Imaging\RecursiveBlobCounter.cs" "Imaging\SusanCornersDetector.cs" "Imaging\TemplateMatch.cs" "Imaging\Textures\CloudsTexture.cs" "Imaging\Textures\ITextureGenerator.cs" "Imaging\Textures\LabyrinthTexture.cs" "Imaging\Textures\MarbleTexture.cs" "Imaging\Textures\TextileTexture.cs" "Imaging\Textures\Texture.cs" "Imaging\Textures\WoodTexture.cs" "Imaging\UnmanagedImage.cs" "Imaging\VerticalIntensityStatistics.cs"
%CONF_COMPILER% /target:library /reference:AForge.Imaging.dll /reference:AForge.dll /out:AForge.Vision.dll /unsafe "Vision\Motion\BlobCountingObjectsProcessing.cs" Vision\Motion\CustomFrameDifferenceDetector.cs Vision\Motion\GridMotionAreaProcessing.cs Vision\Motion\IMotionDetector.cs Vision\Motion\IMotionProcessing.cs Vision\Motion\MotionAreaHighlighting.cs Vision\Motion\MotionBorderHighlighting.cs Vision\Motion\MotionDetector.cs Vision\Motion\SimpleBackgroundModelingDetector.cs Vision\Motion\TwoFramesDifferenceDetector.cs Vision\Properties\AssemblyInfo.cs 

REM
REM Pause
REM 
pause