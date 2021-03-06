﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;

using OhPrimitives;

namespace OhPrimitives.Test
{
    public class RangeFieldTest
    {
        public RangeFieldTest()
        {

        }

        #region Verify_BaseOperatorShouldBeWork

        [Fact]
        public void Verify_BaseOperatorShouldBeWork()
        {
            var myfield = new RangeField<int>(10, 20);

            myfield.Min.ShouldBe(10);
            myfield.Max.ShouldBe(20);

            myfield.MaxCompareMode.ShouldBe(CompareMode.LessThan);
            myfield.MinCompareMode.ShouldBe(CompareMode.GreaterThan);

            myfield.Min = 1000;
            myfield.Max = 2000;
            myfield.Min.ShouldBe(1000);
            myfield.Max.ShouldBe(2000);
        }
        #endregion

        #region Verify_SetPropertyShouldBeSecurity

        [Fact]
        public void Verify_SetPropertyShouldBeSecurity()
        {
            var myfield = new RangeField<int>(10, 20);

            // equal
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.Default; });
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.Equal; });
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.NotEqual; });

            // contains
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.Contains; });
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.NotContains; });

            // like
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.LeftLike; });
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.RightLike; });
            Assert.Throws<ArgumentException>(() => { myfield.MinCompareMode = CompareMode.FullSearchLike; });


            //------- MaxCompareMode ------//

            // equal
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.Default; });
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.Equal; });
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.NotEqual; });

            // contains
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.Contains; });
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.NotContains; });

            // like
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.LeftLike; });
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.RightLike; });
            Assert.Throws<ArgumentException>(() => { myfield.MaxCompareMode = CompareMode.FullSearchLike; });

            // should be work
            myfield.MaxCompareMode = CompareMode.LessThan;
            myfield.MinCompareMode = CompareMode.GreaterThan;
        }
        #endregion
    }
}
